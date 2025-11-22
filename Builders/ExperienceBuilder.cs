using Entity.Models.ModelosParametros;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityCreateRequest;
using Entity.Requests.ModuleOperation;
using Entity.Requests.ModulesParamer;


namespace Builders
{
    /// <summary>
    /// ¿Qué es ExperienceBuilder?
    /// Es una implementación del patrón Builder, que sirve para construir objetos complejos paso a paso.
    /// En este caso, la entidad Experience tiene muchas relaciones (institución, documentos,
    /// objetivos, etc.), y el Builder permite inicializarla de manera flexible y legible.
    /// </summary>
   

    /// <summary>
    /// Builder para crear instancias de la entidad Experience
    /// de forma controlada y paso a paso.
    /// Permite añadir información básica, institución, documentos,
    /// objetivos, líneas temáticas, grados, poblaciones e historial.
    /// </summary>
    public class ExperienceBuilder
    {
        private readonly Experience _experience;

        /// <summary>
        /// Constructor: inicializa la entidad Experience con valores por defecto.
        /// </summary>
        public ExperienceBuilder()
        {
            _experience = new Experience
            {
                State = true, // Estado inicial por defecto
                CreatedAt = DateTime.UtcNow, // Fecha de creación automática
            };
        }

        /// <summary>
        /// Agrega la información básica de la experiencia a partir del DTO.
        /// </summary>
        public ExperienceBuilder WithBasicInfo(ExperienceCreateRequest request)
        {
            _experience.NameExperiences = request.NameExperiences;
            _experience.Code = request.Code;
            _experience.Developmenttime = request.Developmenttime;
            _experience.Recognition = request.Recognition;
            _experience.Socialization = request.Socialization;
            _experience.ThematicLocation = request.ThematicLocation;
            _experience.UserId = request.UserId;
            _experience.StateExperienceId = request.StateExperienceId;
           

            return this;
        }

        public ExperienceBuilder WithLeader(IEnumerable<LeaderCreateRequest> request)
        {
            _experience.Leaders = request.Select(R => new Leader

            {
              NameLeaders =  R.NameLeaders,
              IdentityDocument = R.IdentityDocument,
              Email = R.Email,
              Position = R.Position,
              Phone = R.Phone

            }).ToList();
            return this;
        }
           
        public ExperienceBuilder WithDevelopment(IEnumerable<DevelopmentCreateRequest> request)
        {
            _experience.Developments = request.Select(R => new Development
            { 

                CrossCuttingProject = R.CrossCuttingProject,
                Population = R.Population,
                PedagogicalStrategies = R.PedagogicalStrategies,
                Coverage = R.Coverage,
                CovidPandemic = R.CovidPandemic

            }).ToList();
            return this;
        }





        /// <summary>
        /// Agrega la institución relacionada a la experiencia.
        /// </summary>
        public ExperienceBuilder WithInstitution(InstitutionCreateRequest request)
        {
            var institution = new InstitutionBuilder()
           .WithBasicInfo(request)
           .WithAddress(request.Addresses)
           .WithMunicipality(request.Municipalities)
           .WithEEZone(request.EEZones)
           .WithCommune(request.Communes)
           .WithDepartament(request.Departamentes)

           .Build();

            _experience.Institution = institution;
            return this;
        }


        /// <summary>
        /// Agrega documentos asociados a la experiencia.
        /// </summary>
        public ExperienceBuilder WithDocuments(IEnumerable<DocumentCreateRequest> request)
        {
            _experience.Documents = request.Select(R => new Document
            {
                Name = R.Name,
                UrlLink = R.UrlLink,
                UrlPdf = R.UrlPdf,
                UrlPdfExperience = R.UrlPdfExperience,

               
            }).ToList();
            return this;
        }

        /// <summary>
        /// Agrega objetivos relacionados con la experiencia.
        /// </summary>
        public ExperienceBuilder WithObjective(IEnumerable<ObjectiveCreateRequest> requests)
        {
           

            _experience.Objectives = requests.Select(request =>
                new ObjectiveBuilder()
                    .WithBaseInfo(request)
                    .WithSupportInfo(request.SupportInformations)
                    .WithMonitoring(request.Monitorings)
                    .Build()
            ).ToList();

            return this;
        }


        /// <summary>
        /// Relaciona la experiencia con varias líneas temáticas.
        /// </summary>
        public ExperienceBuilder WithThematics(IEnumerable<int> thematicLineIds)
        {
            _experience.ExperienceLineThematics = thematicLineIds.Select(id => new ExperienceLineThematic
            {
                LineThematicId = id,
                State = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();
            return this;
        }

        /// <summary>
        /// Relaciona grados con la experiencia.
        /// </summary>
        public ExperienceBuilder WithGrades(IEnumerable<GradeCreateRequest> grades)
        {
            _experience.ExperienceGrades = grades.Select(g => new ExperienceGrade
            {
                GradeId = g.GradeId,
                Description = g.Description,
            }).ToList();
            return this;
        }

        /// <summary>
        /// Relaciona poblaciones beneficiarias con la experiencia.
        /// </summary>
        public ExperienceBuilder WithPopulations(IEnumerable<int> populationGradeIds)
        {
            _experience.ExperiencePopulations = populationGradeIds.Select(id => new ExperiencePopulation
            {
                PopulationGradeId = id,
                State = true,
                CreatedAt = DateTime.UtcNow
            }).ToList();
            return this;
        }

        /// <summary>
        /// Registra el historial de cambios/acciones de la experiencia.
        /// Incluye el usuario que hizo el cambio y el estado.
        /// </summary>
        public ExperienceBuilder WithHistory(IEnumerable<HistoryExperienceCreateRequest> historyExperiences, int userId)
        {
            if (historyExperiences != null)
            {
                _experience.HistoryExperiences = historyExperiences.Select(h => new HistoryExperience
                {
                    Action = h.Action,
                    TableName = h.TableName,
                    UserId = userId,
                    
                }).ToList();
            }
            return this;
        }

        /// <summary>
        /// Devuelve la entidad Experience construida.
        /// </summary>
        public Experience Build() => _experience;
    }
}
