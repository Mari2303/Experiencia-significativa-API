using Entity.Dtos.ModuleOperational;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleOperation;
using Microsoft.Extensions.Options;
using Repository.Implementations.ModuleOperationRepository;
using Repository.Interfaces.IModuleOperationRepository;
using Service.Extensions;
using Service.Implementations.ModuleBaseService;
using Service.Interfaces.ModelOperationService;
using Utilities.CreatedPdf.templatePdfs;
using Utilities.Email.Interfaces;

namespace Service.Implementations.ModelOperationService
{
    public class EvaluationService : BaseModelService<Evaluation, EvaluationDTO, EvaluationRequest>, IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly SupabaseStorageService _storage;
        private readonly IEmailEvaluationBrevoService _brevoEmailService;
        private readonly PdfSettingsRequest _pdfSettings;

        public EvaluationService(IEvaluationRepository evaluationRepository, SupabaseStorageService storage, IEmailEvaluationBrevoService brevoEmailService, IOptions<PdfSettingsRequest> pdfSettings) : base(evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
            _storage = storage;
            _brevoEmailService = brevoEmailService;
            _pdfSettings = pdfSettings.Value;
        }


        public async Task<EvaluationDetailRequest> CreateEvaluationAsync(EvaluationCreateRequest request)
        {
            var experience = await _evaluationRepository.GetExperienceWithInstitutionAsync(request.ExperienceId)
                ?? throw new KeyNotFoundException("La experiencia no existe");

            var builder = new EvaluationBuilder(request)
                .AddCriteriaScores(request.EvaluationCriteriaDetail);

            var (evaluation, criteriaList) = builder.Build();
            evaluation = await _evaluationRepository.AddEvaluationAsync(evaluation);

            foreach (var c in criteriaList)
            {
                c.EvaluationId = evaluation.Id;
                await _evaluationRepository.AddEvaluationCriteriaAsync(c);
            }

            foreach (var c in request.EvaluationCriteriaDetail)
            {
                var criteria = await _evaluationRepository.GetCriteriaByIdAsync(c.CriteriaId);
                if (criteria != null)
                {
                    await _evaluationRepository.UpdateCriteriaAsync(criteria);
                }
            }

          


            var evaluationDetail = await _evaluationRepository.GetEvaluationDetailAsync(evaluation.Id);

            //  Luego enviamos el correo después, sin afectar el contexto de datos
            _ = Task.Run(async () =>
            {
                try
                {
                    if (!string.IsNullOrEmpty(evaluationDetail.Email))
                    {
                        await _brevoEmailService.SendEvaluationResultEmailAsync(
                            evaluationDetail.Email,
                            evaluationDetail.UserName,
                            evaluationDetail.EvaluationResult
                        );
                    }
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine($"Error enviando correo: {ex.Message}");
                }
            });
            return evaluationDetail;
        }




        public async Task<EvaluationDetailRequest> UpdateEvaluationAsync(int evaluationId, EvaluationUpdateRequest request)
        {
            // 1️⃣ Obtener evaluación con tracking
            var evaluationEntity = await _evaluationRepository.GetEvaluationByIdTrackedAsync(evaluationId);
            if (evaluationEntity == null)
                throw new KeyNotFoundException("No se encontró la evaluación.");

            evaluationEntity.ApplyPatch(request);

            //  Guardar en base de datos
            await _evaluationRepository.SaveChangesAsync();
            var evaluationDetail = await _evaluationRepository.GetEvaluationDetailAsync(evaluationId);

            // Enviar correo con el resultado actualizado
            if (!string.IsNullOrEmpty(evaluationDetail.Email))
            {
                await _brevoEmailService.SendEvaluationResultEmailAsync(
                    evaluationDetail.Email,
                    evaluationDetail.UserName,
                    evaluationDetail.EvaluationResult
                );
            }
            return evaluationDetail;
        }




        public async Task<string> GenerateAndAttachPdfAsync(int evaluationId)
        {
            var evaluationDto = await _evaluationRepository.GetEvaluationDetailAsync(evaluationId)
                ?? throw new KeyNotFoundException("La evaluación no existe.");
            var logoUrl = _pdfSettings.LogoUrl;
            if (string.IsNullOrWhiteSpace(logoUrl))
                throw new Exception("No se ha configurado la URL del logo en PdfSettings.");

            var logoBytes = await EvaluationPdfGenerator.LoadImageFromUrlAsync(logoUrl);

            var pdfBytes = EvaluationPdfGenerator.Generate(evaluationDto, logoBytes);

            string pdfUrl = await _storage.UploadEvaluationPdfToSupabase(pdfBytes, evaluationId);
            await _evaluationRepository.UpdateEvaluationPdfUrlAsync(evaluationId, pdfUrl);

            return pdfUrl;
        }




        public async Task<IEnumerable<Experience>> FilterInitialEvaluationAsync()
        {
            return await _evaluationRepository.GetExperiencesWithInitialEvaluationAsync();
        }

        public async Task<IEnumerable<Experience>> FilterFinalEvaluationAsync()
        {
            return await _evaluationRepository.GetExperiencesWithFinalEvaluationAsync();
        }

        public async Task<IEnumerable<Experience>> FilterWithoutEvaluationAsync()
        {
            return await _evaluationRepository.GetExperiencesWithoutEvaluationAsync();
        }







    }
}

