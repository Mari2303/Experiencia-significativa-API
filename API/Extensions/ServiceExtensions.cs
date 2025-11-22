using Entity.Dtos;
using Entity.Dtos.ModelosParametro;
using Entity.Dtos.ModuleBase;
using Entity.Dtos.ModuleGeographic;
using Entity.Dtos.ModuleOperation;
using Entity.Dtos.ModuleOperational;
using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Models.ModelosParametros;
using Entity.Models.ModuleBase;
using Entity.Models.ModuleGeographic;
using Entity.Models.ModuleOperation;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleGeographic;
using Entity.Requests.ModuleOperation;
using Entity.Requests.ModuleParameter;
using Entity.Requests.ModuleSegurity;
using Entity.Requests.ModulesParamer;
using Repository.Implementations;
using Repository.Implementations.ModuleGeographicRepository;
using Repository.Implementations.ModuleOperationRepository;
using Repository.Implementations.ModulePararmer;
using Repository.Implementations.ModuleSegurityRepository;
using Repository.Interfaces;
using Repository.Interfaces.IModuleGeographicRepository;
using Repository.Interfaces.IModuleOperationRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Repository.Interfaces.ModuleParamer;
using Service.Implementations.ModelOperationService;
using Service.Implementations.ModuleBaseService;
using Service.Implementations.ModuleGeographicService;
using Service.Implementations.ModuleParamer;
using Service.Implementations.ModuleSegurityService;
using Service.Interfaces.IModuleBaseService;
using Service.Interfaces.IModuleGeographicService;
using Service.Interfaces.IModuleSegurityService;
using Service.Interfaces.ModelOperationService;
using Service.Interfaces.ModuleParamer;
using Utilities.Helper;

namespace API
{
    /// <summary>
    /// Clase de extensión para registrar todos los servicios y repositorios en el contenedor de inyección de dependencias.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Método para agregar todos los servicios personalizados de la aplicación al contenedor de servicios.
        /// Aquí se registra cada Repository, Service, Helper, y sus interfaces para que puedan ser inyectados.
        /// </summary>
        /// <param name="services">La colección de servicios de ASP.NET Core.</param>
        public static void AddCustomServices(IServiceCollection services)
        {
            // ============================
            // Servicios de Autenticación
            // ============================
            services.AddScoped<IAuthService, AuthService>(); // Servicio de autenticación
            services.AddScoped<IAuthRepository, AuthRepository>(); // Repositorio para autenticación

            // ============================
            // Servicios Helper genéricos
            // ============================
            services.AddScoped<IHelperService<BaseModel, BaseDTO>, HelperService<BaseModel, BaseDTO>>();
            services.AddScoped<IHelper<BaseModel, BaseDTO>, Helper<BaseModel, BaseDTO>>();

            // ============================
            // Registro de User (usuario)
            // ============================
            // Se registra repositorio, servicio y helpers específicos para User
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBaseModelService<User, UserDTO, UserRequest>, UserService>();
            services.AddScoped<IHelperService<User, UserDTO>, HelperService<User, UserDTO>>();
            services.AddScoped<IHelper<User, UserDTO>, Helper<User, UserDTO>>();

            // ============================
            // Registro de Person
            // ============================
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBaseModelService<Person, PersonDTO, PersonRequest>, PersonService>();
            services.AddScoped<IHelperService<Person, PersonDTO>, HelperService<Person, PersonDTO>>();
            services.AddScoped<IHelper<Person, PersonDTO>, Helper<Person, PersonDTO>>();

            // ============================
            // Registro de Role
            // ============================
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IBaseModelService<Role, RoleDTO, RoleRequest>, RoleService>();
            services.AddScoped<IHelperService<Role, RoleDTO>, HelperService<Role, RoleDTO>>();
            services.AddScoped<IHelper<Role, RoleDTO>, Helper<Role, RoleDTO>>();

            // ============================
            // Registro de Form
            // ============================
            services.AddScoped<IFormRepository, FormRepository>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IBaseModelService<Form, FormDTO, FormRequest>, FormService>();
            services.AddScoped<IHelperService<Form, FormDTO>, HelperService<Form, FormDTO>>();
            services.AddScoped<IHelper<Form, FormDTO>, Helper<Form, FormDTO>>();

            // ============================
            // Registro de Module (módulo)
            // ============================
            services.AddScoped<IBaseModuleRepository, ModuleRepository>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IBaseModelService<Module, ModuleDTO, ModuleRequest>, ModuleService>();
            services.AddScoped<IHelperService<Module, ModuleDTO>, HelperService<Module, ModuleDTO>>();
            services.AddScoped<IHelper<Module, ModuleDTO>, Helper<Module, ModuleDTO>>();

            // ============================
            // Registro de Permission
            // ============================
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IBaseModelService<Permission, PermissionDTO, PermissionRequest>, PermissionService>();
            services.AddScoped<IHelperService<Permission, PermissionDTO>, HelperService<Permission, PermissionDTO>>();
            services.AddScoped<IHelper<Permission, PermissionDTO>, Helper<Permission, PermissionDTO>>();

            // ============================
            // Registro de UserRole
            // ============================
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IBaseModelService<UserRole, UserRoleDTO, UserRoleRequest>, UserRoleService>();
            services.AddScoped<IHelperService<UserRole, UserRoleDTO>, HelperService<UserRole, UserRoleDTO>>();
            services.AddScoped<IHelper<UserRole, UserRoleDTO>, Helper<UserRole, UserRoleDTO>>();

            // ============================
            // Registro de FormModule
            // ============================
            services.AddScoped<IFormModuleRepository, FormModuleRepository>();
            services.AddScoped<IFormModuleService, FormModuleService>();
            services.AddScoped<IBaseModelService<FormModule, FormModuleDTO, FormModuleRequest>, FormModuleService>();
            services.AddScoped<IHelperService<FormModule, FormModuleDTO>, HelperService<FormModule, FormModuleDTO>>();
            services.AddScoped<IHelper<FormModule, FormModuleDTO>, Helper<FormModule, FormModuleDTO>>();

            // ============================
            // Registro de RoleFormPermission
            // ============================
            services.AddScoped<IRoleFormPermissionRepository, RoleFormPermissionRepository>();
            services.AddScoped<IRoleFormPermissionService, RoleFormPermissionService>();
            services.AddScoped<IBaseModelService<RoleFormPermission, RoleFormPermissionDTO, RoleFormPermissionRequest>, RoleFormPermissionService>();
            services.AddScoped<IHelperService<RoleFormPermission, RoleFormPermissionDTO>, HelperService<RoleFormPermission, RoleFormPermissionDTO>>();
            services.AddScoped<IHelper<RoleFormPermission, RoleFormPermissionDTO>, Helper<RoleFormPermission, RoleFormPermissionDTO>>();

            // ============================
            // Registro de Criteria, Grade, State, LineThematic, PopulationGrade
            // ============================
            services.AddScoped<ICriteriaRepository, CriteriaRepository>();
            services.AddScoped<ICriteriaService, CriteriaService>();
            services.AddScoped<IBaseModelService<Criteria, CriteriaDTO, CriteriaRequest>, CriteriaService>();
            services.AddScoped<IHelperService<Criteria, CriteriaDTO>, HelperService<Criteria, CriteriaDTO>>();
            services.AddScoped<IHelper<Criteria, CriteriaDTO>, Helper<Criteria, CriteriaDTO>>();

            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IBaseModelService<Grade, GradeDTO, GradeRequest>, GradeService>();
            services.AddScoped<IHelperService<Grade, GradeDTO>, HelperService<Grade, GradeDTO>>();
            services.AddScoped<IHelper<Grade, GradeDTO>, Helper<Grade, GradeDTO>>();

            services.AddScoped<IStateExperienceRepository, StateExperienceRepository>();
            services.AddScoped<IStateExperienceService, StateExperienceService>();
            services.AddScoped<IBaseModelService<StateExperience, StateExperienceDTO, StateExperienceRequest>, StateExperienceService>();
            services.AddScoped<IHelperService<StateExperience, StateExperienceDTO>, HelperService<StateExperience, StateExperienceDTO>>();
            services.AddScoped<IHelper<StateExperience, StateExperienceDTO>, Helper<StateExperience, StateExperienceDTO>>();

            services.AddScoped<ILineThematicRepository, LineThematicRepository>();
            services.AddScoped<ILineThematicService, LineThematicService>();
            services.AddScoped<IBaseModelService<LineThematic, LineThematicDTO, LineThematicRequest>, LineThematicService>();
            services.AddScoped<IHelperService<LineThematic, LineThematicDTO>, HelperService<LineThematic, LineThematicDTO>>();
            services.AddScoped<IHelper<LineThematic, LineThematicDTO>, Helper<LineThematic, LineThematicDTO>>();

            services.AddScoped<IPopulationGradeRepository, PopulationGradeRepository>();
            services.AddScoped<IPopulationGradeService, PopulationGradeService>();
            services.AddScoped<IBaseModelService<PopulationGrade, PopulationGradeDTO, PopulationGradeRequest>, PopulationGradeService>();
            services.AddScoped<IHelperService<PopulationGrade, PopulationGradeDTO>, HelperService<PopulationGrade, PopulationGradeDTO>>();
            services.AddScoped<IHelper<PopulationGrade, PopulationGradeDTO>, Helper<PopulationGrade, PopulationGradeDTO>>();

            // ============================
            // Registro de Document, Evaluation y sus componentes
            // ============================
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IBaseModelService<Document, DocumentDTO, DocumentRequest>, DocumentService>();
            services.AddScoped<IHelperService<Document, DocumentDTO>, HelperService<Document, DocumentDTO>>();
            services.AddScoped<IHelper<Document, DocumentDTO>, Helper<Document, DocumentDTO>>();

            services.AddScoped<IEvaluationRepository, EvaluationRepository>();
            services.AddScoped<IEvaluationService, EvaluationService>();
            services.AddScoped<IBaseModelService<Evaluation, EvaluationDTO, EvaluationRequest>, EvaluationService>();
            services.AddScoped<IHelperService<Evaluation, EvaluationDTO>, HelperService<Evaluation, EvaluationDTO>>();
            services.AddScoped<IHelper<Evaluation, EvaluationDTO>, Helper<Evaluation, EvaluationDTO>>();

            services.AddScoped<IEvaluationCriteriaRepository, EvaluationCriteriaRepository>();
            services.AddScoped<IEvaluationCriteriaService, EvaluationCriteriaService>();
            services.AddScoped<IBaseModelService<EvaluationCriteria, EvaluationCriteriaDTO, EvaluationCriteriaRequest>, EvaluationCriteriaService>();
            services.AddScoped<IHelperService<EvaluationCriteria, EvaluationCriteriaDTO>, HelperService<EvaluationCriteria, EvaluationCriteriaDTO>>();
            services.AddScoped<IHelper<EvaluationCriteria, EvaluationCriteriaDTO>, Helper<EvaluationCriteria, EvaluationCriteriaDTO>>();

            // ============================
            // Registro de Experience y sus componentes
            // ============================
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IBaseModelService<Experience, ExperienceDTO, ExperienceRequest>, ExperienceService>();
            services.AddScoped<IHelperService<Experience, ExperienceDTO>, HelperService<Experience, ExperienceDTO>>();
            services.AddScoped<IHelper<Experience, ExperienceDTO>, Helper<Experience, ExperienceDTO>>();

            services.AddScoped<IExperienceGradeRepository, ExperienceGradeRepository>();
            services.AddScoped<IExperienceGradeService, ExperienceGradeService>();
            services.AddScoped<IBaseModelService<ExperienceGrade, ExperienceGradeDTO, ExperienceGradeRequest>, ExperienceGradeService>();
            services.AddScoped<IHelperService<ExperienceGrade, ExperienceGradeDTO>, HelperService<ExperienceGrade, ExperienceGradeDTO>>();
            services.AddScoped<IHelper<ExperienceGrade, ExperienceGradeDTO>, Helper<ExperienceGrade, ExperienceGradeDTO>>();

            services.AddScoped<IExperienceLineThematicRepository, ExperienceLineThematicRepository>();
            services.AddScoped<IExperienceLineThematicService, ExperienceLineThematicService>();
            services.AddScoped<IBaseModelService<ExperienceLineThematic, ExperienceLineThematicDTO, ExperienceLineThematicRequest>, ExperienceLineThematicService>();
            services.AddScoped<IHelperService<ExperienceLineThematic, ExperienceLineThematicDTO>, HelperService<ExperienceLineThematic, ExperienceLineThematicDTO>>();
            services.AddScoped<IHelper<ExperienceLineThematic, ExperienceLineThematicDTO>, Helper<ExperienceLineThematic, ExperienceLineThematicDTO>>();

            services.AddScoped<IExperiencePopulationRepository, ExperiencePopulationRepository>();
            services.AddScoped<IExperiencePopulationService, ExperiencePopulationService>();
            services.AddScoped<IBaseModelService<ExperiencePopulation, ExperiencePopulationDTO, ExperiencePopulationRequest>, ExperiencePopulationService>();
            services.AddScoped<IHelperService<ExperiencePopulation, ExperiencePopulationDTO>, HelperService<ExperiencePopulation, ExperiencePopulationDTO>>();
            services.AddScoped<IHelper<ExperiencePopulation, ExperiencePopulationDTO>, Helper<ExperiencePopulation, ExperiencePopulationDTO>>();

            // ============================
            // Registro de HistoryExperience, Institution, Objective y Verification
            // ============================
            services.AddScoped<IHistoryExperienceRepository, HistoryExperienceRepository>();
            services.AddScoped<IHistoryExperienceService, HistoryExperienceService>();
            services.AddScoped<IBaseModelService<HistoryExperience, HistoryExperienceDTO, HistoryExperienceRequest>, HistoryExperienceService>();
            services.AddScoped<IHelperService<HistoryExperience, HistoryExperienceDTO>, HelperService<HistoryExperience, HistoryExperienceDTO>>();
            services.AddScoped<IHelper<HistoryExperience, HistoryExperienceDTO>, Helper<HistoryExperience, HistoryExperienceDTO>>();

            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<IBaseModelService<Institution, InstitutionDTO, InstitutionRequest>, InstitutionService>();
            services.AddScoped<IHelperService<Institution, InstitutionDTO>, HelperService<Institution, InstitutionDTO>>();
            services.AddScoped<IHelper<Institution, InstitutionDTO>, Helper<Institution, InstitutionDTO>>();

            services.AddScoped<IObjectiveRepository, ObjectiveRepository>();
            services.AddScoped<IObjectiveService, ObjectiveService>();
            services.AddScoped<IBaseModelService<Objective, ObjectiveDTO, ObjectiveRequest>, ObjectiveService>();
            services.AddScoped<IHelperService<Objective, ObjectiveDTO>, HelperService<Objective, ObjectiveDTO>>();
            services.AddScoped<IHelper<Objective, ObjectiveDTO>, Helper<Objective, ObjectiveDTO>>();

            services.AddScoped<IDevelopmentRepository, DevelopmentRepository>();
            services.AddScoped<IDevelopmentService, DevelopmentService>();
            services.AddScoped<IBaseModelService<Development, DevelopmentDTO, DevelopmentRequest>, DevelopmentService>();
            services.AddScoped<IHelperService<Development, DevelopmentDTO>, HelperService<Development, DevelopmentDTO>>();
            services.AddScoped<IHelper<Development, DevelopmentDTO>, Helper<Development, DevelopmentDTO>>();



            // Registro de Leader
            services.AddScoped<ILeaderRepository, LeaderRepository>();
            services.AddScoped<ILeaderService, LeaderService>();
            services.AddScoped<IBaseModelService<Leader, LeaderDTO, LeaderRequest>, LeaderService>();
            services.AddScoped<IHelperService<Leader, LeaderDTO>, HelperService<Leader, LeaderDTO>>();
            services.AddScoped<IHelper<Leader, LeaderDTO>, Helper<Leader, LeaderDTO>>();

            // registro de Monitoring
            services.AddScoped<IMonitoringRepository, MonitoringRepository>();
            services.AddScoped<IMonitoringService, MonitoringService>();
            services.AddScoped<IBaseModelService<Monitoring, MonitoringDTO, MonitoringRequest>, MonitoringService>();
            services.AddScoped<IHelperService<Monitoring, MonitoringDTO>, HelperService<Monitoring, MonitoringDTO>>();
            services.AddScoped<IHelper<Monitoring, MonitoringDTO>, Helper<Monitoring, MonitoringDTO>>();

            // reistro de SupportInformation
            services.AddScoped<ISupportInformationRepository, SupportInformationRepository>();
            services.AddScoped<ISupportInformationService, SupportInformationService>();
            services.AddScoped<IBaseModelService<SupportInformation, SupportInformationDTO, SupportInformationRequest>, SupportInformationService>();
            services.AddScoped<IHelperService<SupportInformation, SupportInformationDTO>, HelperService<SupportInformation, SupportInformationDTO>>();
            services.AddScoped<IHelper<SupportInformation, SupportInformationDTO>, Helper<SupportInformation, SupportInformationDTO>>();


            // registro modulo geographic

            services.AddScoped<IDepartamentRepository, DepartamentRepository>();
            services.AddScoped<IDepartamentService, DepartamentService>();
            services.AddScoped<IBaseModelService<Departament, DepartamentDTO, DepartamentRequest>, DepartamentService>();
            services.AddScoped<IHelperService<Departament, DepartamentDTO>, HelperService<Departament, DepartamentDTO>>();
            services.AddScoped<IHelper<Departament, DepartamentDTO>, Helper<Departament, DepartamentDTO>>();

            services.AddScoped<IMunicipalityRepository, MunicipalityRepository>();
            services.AddScoped<IMunicipalityService, MunicipalityService>();
            services.AddScoped<IBaseModelService<Municipality, MunicipalityDTO, MunicipalityRequest>, MunicipalityService>();
            services.AddScoped<IHelperService<Municipality, MunicipalityDTO>, HelperService<Municipality, MunicipalityDTO>>();
            services.AddScoped<IHelper<Municipality, MunicipalityDTO>, Helper<Municipality, MunicipalityDTO>>();


            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IBaseModelService<Address, AddressDTO, AddressRequest>, AddressService>();
            services.AddScoped<IHelperService<Address, AddressDTO>, HelperService<Address, AddressDTO>>();
            services.AddScoped<IHelper<Address, AddressDTO>, Helper<Address, AddressDTO>>();


            services.AddScoped<ICommuneRepository, CommuneRepository>();
            services.AddScoped<ICommuneService, CommuneService>();
            services.AddScoped<IBaseModelService<Commune, CommuneDTO, CommuneRequest>, CommuneService>();
            services.AddScoped<IHelperService<Commune, CommuneDTO>, HelperService<Commune, CommuneDTO>>();
            services.AddScoped<IHelper<Commune, CommuneDTO>, Helper<Commune, CommuneDTO>>();

            services.AddScoped<IEEZoneRepository, EEZoneRepository>();
            services.AddScoped<IEEZoneService, EEZoneService>();
            services.AddScoped<IBaseModelService<EEZone, EEZoneDTO, EEZoneRequest>, EEZoneService>();
            services.AddScoped<IHelperService<EEZone, EEZoneDTO>, HelperService<EEZone, EEZoneDTO>>();
            services.AddScoped<IHelper<EEZone, EEZoneDTO>, Helper<EEZone, EEZoneDTO>>();

            









        }
    }
}