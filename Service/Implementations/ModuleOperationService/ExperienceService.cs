using Builders;
using Entity.Dtos.ModuleOperation;
using Entity.Dtos.ModuleOperational;
using Entity.Models;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleOperation;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.Implementations.ModuleOperationRepository;
using Repository.Interfaces.IModuleOperationRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Service.Extensions;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;
using Utilities.CreatedPdf.Service;


namespace Service.Implementations.ModelOperationService
{
    public class ExperienceService : BaseModelService<Experience, ExperienceDTO, ExperienceRequest>, IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly SubeBaseExperienceStorage _storage;
        private readonly PdfSettingsRequest _pdfSettings;
        private readonly IHubContext<NotificationHub> _hubContext;
        private readonly IExperienceEditPermissionRepository _permissionRepo;
        private readonly IUserRepository _userRepository;
      
        public ExperienceService(IExperienceRepository experienceRepository, SubeBaseExperienceStorage storage, IOptions<PdfSettingsRequest> pdfSettings, IHubContext<NotificationHub> hubContext, IExperienceEditPermissionRepository permissionRepo, IUserRepository userRepository) : base(experienceRepository)
        {
            _experienceRepository = experienceRepository;
            _storage = storage;
            _pdfSettings = pdfSettings.Value;
            _hubContext = hubContext;
            _permissionRepo = permissionRepo;
            _userRepository = userRepository;
        }

 

        public async Task<Experience> RegisterExperienceAsync(ExperienceCreateRequest request)
        {
            try
            {
                var experience = new ExperienceBuilder()
                    .WithBasicInfo(request)
                    .WithInstitution(request.Institution)
                   .WithDocuments(request.Documents)
                   .WithDevelopment(request.Developments)
                   .WithLeader(request.Leaders)
                  .WithObjective(request.Objectives)
                    .WithThematics(request.ThematicLineIds)
                    .WithGrades(request.Grades)
                    .WithPopulations(request.PopulationGradeIds)
                    .WithHistory(request.HistoryExperiences, request.UserId)
                    .Build();

                await _experienceRepository.AddAsync(experience);

                // ENVIAR NOTIFICACIÓN AL ADMIN VÍA SIGNALR
                await _hubContext.Clients.All.SendAsync("ReceiveNotification", new
                {
                    Title = "Nueva experiencia registrada",
                    ExperienceName = experience.NameExperiences,
                    CreatedBy = experience.User?.Person?.FirstName
                                ?? experience.User?.Username
                                ?? "Usuario no identificado",
                    Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                });

               
                return experience;
            }
            catch (DbUpdateException dbEx)
            {
                var innerMessage = dbEx.InnerException?.Message ?? dbEx.Message;
                throw new Exception($"Error al registrar la experiencia (DB): {innerMessage}", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error general al registrar la experiencia: {ex.Message}", ex);
            }
        }


        public async Task<ExperienceDetailRequest?> GetDetailByIdAsync(int id)
        {
            var experience = await _experienceRepository.GetByIdWithDetailsAsync(id);
            return experience?.ToDetailRequest();
        }


        public async Task<bool> PatchAsync(ExperienceUpdateRequest request)
        {
            var experience = await _experienceRepository.GetByIdWithDetailsAsync(request.ExperienceId);

            if (experience == null)
                return false;

            // Obtener roles del usuario
            var roles = await _userRepository.GetRolesByUserId(request.UserId);

            // ADMIN = edición ilimitada
            if (roles.Contains("SUPERADMIN"))
            {
                experience.ApplyPatch(request);
                await _experienceRepository.UpdateAsync(experience);
                await NotifyAdmins(experience);
                return true;
            }

            // Si NO es admin  validar permiso
            var permission = await _permissionRepo.GetByExperienceIdAsync(request.ExperienceId);

            if (permission == null || !permission.Approved)
                throw new Exception("No tienes permiso para editar esta experiencia.");

            // Validar expiración
            if (permission.ExpiresAt == null || permission.ExpiresAt < DateTime.UtcNow)
                throw new Exception("El tiempo de edición expiró. Debes solicitar permiso nuevamente.");

            // APLICAR PATCH 
            experience.ApplyPatch(request);
            await _experienceRepository.UpdateAsync(experience);

            return true;
        }


        private async Task NotifyAdmins(Experience experience)
        {
            await _hubContext.Clients.Group("Admins").SendAsync("ExperienceUpdated", new
            {
                Message = "Una experiencia ha sido actualizada",
                ExperienceId = experience.Id,
                Name = experience.NameExperiences,
                UpdatedAt = DateTime.UtcNow
            });
        }




        public async Task<IEnumerable<Experience>> GetExperiencesAsync(string role, int userId)
        {
            if (role == "Profesor")
                return await _experienceRepository.GetByUserIdAsync(userId);

            
            return await _experienceRepository.GetAllAsync();
        }







        public async Task<string> GeneratePdfAndUploadAsync(int experienceId)
        {
            // Obtener experiencia con relaciones
            var experience = await _experienceRepository.GetByIdWithDetailsAsync(experienceId)
                ?? throw new Exception("La experiencia no existe");

            // === Cargar logo de PdfSettings ===
            var logoUrl = _pdfSettings.LogoUrl;
            if (string.IsNullOrWhiteSpace(logoUrl))
                throw new Exception("No se ha configurado la URL del logo en PdfSettings.");

            var logoBytes = await ExperiencePdfGenerator.LoadImageFromUrlSafeAsync(logoUrl);

            if (logoBytes == null)
                throw new Exception("No se pudo cargar el logo desde la URL configurada.");

            // === Generar PDF enviando el logo ===
            var pdfBytes = ExperiencePdfGenerator.Generate(experience, logoBytes);

            // === Subir PDF a Supabase ===
            var url = await _storage.UploadExperiencePdfToSupabase(pdfBytes, experienceId);

            // === Guardar URL en BD ===
            experience.UrlPdf = url;
            await _experienceRepository.UpdateAsync(experience);

            return url;
        }





        public async Task RequestEditAsync(int experienceId, int userId)
        {
            //  Verificar si existe la experiencia
            var experience = await _experienceRepository.GetByIdAsync(experienceId);
            if (experience == null)
                throw new Exception("La experiencia no existe.");

            //  Verificar si ya tiene una solicitud
            var existing = await _permissionRepo.GetByExperienceIdAsync(experienceId);
            if (existing != null)
                throw new Exception("Ya existe una solicitud para esta experiencia.");

            //  Crear solicitud
            var permission = new ExperienceEditPermission
            {
                ExperienceId = experienceId,
                UserId = userId,
                CreatedAt = DateTime.UtcNow,
                Approved = false,
               
            };

            await _permissionRepo.AddAsync(permission);
        }







        // Un método para aprobar la edición con expiración de 30 minutos
        public async Task ApproveEditAsync(int experienceId)
        {
            var permission = await _permissionRepo.GetByExperienceIdAsync(experienceId)
                ?? throw new Exception("No existe solicitud de edición");

            permission.Approved = true;
            permission.CreatedAt = DateTime.UtcNow;

            // AGREGAR EXPIRACIÓN DE 30 MINUTOS
            permission.ExpiresAt = DateTime.UtcNow.AddMinutes(30);

            await _permissionRepo.UpdateAsync(permission);
        }





        public async Task<List<ExperienceEditPermissionDTO>> GetAllAsync()
        {
            var list = await _permissionRepo.GetAllAsync();

            return list.Select(p => new ExperienceEditPermissionDTO
            {
                Id = p.Id,
                ExperienceId = p.ExperienceId,
                ExperienceName = p.Experience?.NameExperiences ?? "",
                UserId = p.UserId,
                UserName = p.User?.Username ?? "",
                Approved = p.Approved
            }).ToList();
        }


        public async Task<Experience?> GetDetailAsync(int id)
        {
            return await _experienceRepository.GetDetailByIdAsync(id);
        }





    }


}
