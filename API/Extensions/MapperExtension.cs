using Utilities.JwtAuthentication;
using Utilities.Mappers;
using Utilities.Mappers.ModuleGeographic;
using Utilities.Mappers.ModuleOperation;
using Utilities.Mappers.ModuleSegurity;
using Utilities.Mappers.ModulesParamer;

namespace API
{
    /// <summary>
    /// Extensión para configurar AutoMapper en la aplicación.
    /// </summary>
    class MapperExtension
    {
        /// <summary>
        /// Configura los perfiles de AutoMapper para la aplicación.
        /// </summary>
        /// <param name="services">La colección de servicios donde se agregarán los perfiles de AutoMapper.</param>
        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            // Crear instancias de los perfiles de AutoMapper
            var jwtAuthentication = services.BuildServiceProvider().GetService<IJwtAuthentication>();
            var formProfiles = new FormProfiles();
            var formModuleProfiles = new FormModuleProfiles();
            var moduleProfiles = new ModuleProfiles();
            var permissionProfiles = new PermissionProfiles();
            var personProfiles = new PersonProfiles();
            var roleFormPermissionProfiles = new RoleFormPermissionProfiles();
            var roleProfiles = new RoleProfiles();
            var userProfiles = new UserProfiles(jwtAuthentication);
            var userRoleProfiles = new UserRoleProfiles();
            var criteriaProfiles = new CriteriaProfiles();
            var gradeProfiles = new GradeProfiles();
            var stateExperienceProfiles = new StateExperienceProfiles();
            var lineThematicProfiles = new LineThematicProfiles();
            var populationGradeProfiles = new PopulationGradeProfiles();

            var documentProfiles = new DocumentProfiles();
            var evaluationProfiles = new EvaluationProfiles();
            var evaluationCriteriaProfiles = new EvaluationCriteriaProfiles();
            var experienceGradeProfiles = new ExperienceGradeProfiles();
            var experienceProfiles = new ExperienceProfiles();
            var experienceLineThematicProfiles = new ExperienceLineThematicProfiles();
            var experiencePopulationProfiles = new ExperiencePopulationProfiles();
            var historyExperienceProfiles = new HistoryExperienceProfiles();
            var objectiveProfiles = new ObjectiveProfiles();
            var verificationProfiles = new DevelopmentProfiles();
            var institutionProfiles = new InstitutionProfiles();
            var developmentProfiles = new DevelopmentProfiles();
            var leaderProfiles = new LeaderProfiles();
            var monitoringProfiles = new MonitoringProfiles();
            var supportInformationProfiles = new SupportInformationProfiles();


            var departamentProfiles = new DepartamentProfiles();
            var municipalityProfiles = new MunicipalityProfiles();
            var communeProfiles = new CommuneProfiles();
            var eeZoneProfiles = new EEZoneProfiles();
            var addressProfiles = new AddressProfiles();

            // Registrar los perfiles de AutoMapper en los servicios
            services.AddAutoMapper(_ => _.AddProfile(formProfiles));
            services.AddAutoMapper(_ => _.AddProfile(formModuleProfiles));
            services.AddAutoMapper(_ => _.AddProfile(moduleProfiles));
            services.AddAutoMapper(_ => _.AddProfile(permissionProfiles));
            services.AddAutoMapper(_ => _.AddProfile(personProfiles));
            services.AddAutoMapper(_ => _.AddProfile(roleFormPermissionProfiles));
            services.AddAutoMapper(_ => _.AddProfile(roleProfiles));
            services.AddAutoMapper(_ => _.AddProfile(userProfiles));
            services.AddAutoMapper(_ => _.AddProfile(userRoleProfiles));
            services.AddAutoMapper(_ => _.AddProfile(criteriaProfiles));
            services.AddAutoMapper(_ => _.AddProfile(gradeProfiles));
            services.AddAutoMapper(_ => _.AddProfile(stateExperienceProfiles));
            services.AddAutoMapper(_ => _.AddProfile(populationGradeProfiles));
            services.AddAutoMapper(_ => _.AddProfile(lineThematicProfiles));

            services.AddAutoMapper(_ => _.AddProfile(documentProfiles));
            services.AddAutoMapper(_ => _.AddProfile(evaluationProfiles));
            services.AddAutoMapper(_ => _.AddProfile(evaluationCriteriaProfiles));
            services.AddAutoMapper(_ => _.AddProfile(experienceGradeProfiles));
            services.AddAutoMapper(_ => _.AddProfile(experienceProfiles));
            services.AddAutoMapper(_ => _.AddProfile(experienceLineThematicProfiles));
            services.AddAutoMapper(_ => _.AddProfile(experiencePopulationProfiles));
            services.AddAutoMapper(_ => _.AddProfile(historyExperienceProfiles));
            services.AddAutoMapper(_ => _.AddProfile(objectiveProfiles));
            services.AddAutoMapper(_ => _.AddProfile(verificationProfiles));
            services.AddAutoMapper(_ => _.AddProfile(institutionProfiles));
            services.AddAutoMapper(_ => _.AddProfile(developmentProfiles));
            services.AddAutoMapper(_ => _.AddProfile(leaderProfiles));
            services.AddAutoMapper(_ => _.AddProfile(monitoringProfiles));
            services.AddAutoMapper(_ => _.AddProfile(supportInformationProfiles));


            services.AddAutoMapper(_ => _.AddProfile(departamentProfiles));
            services.AddAutoMapper(_ => _.AddProfile(municipalityProfiles));
            services.AddAutoMapper(_ => _.AddProfile(communeProfiles));
            services.AddAutoMapper(_ => _.AddProfile(eeZoneProfiles));
            services.AddAutoMapper(_ => _.AddProfile(addressProfiles));

        }
    }
}
