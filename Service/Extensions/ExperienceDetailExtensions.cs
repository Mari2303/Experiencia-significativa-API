
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityDataRequest;
using Entity.Requests.EntityData.EntityDetailRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;

namespace Service.Extensions
{
    ///<summary>
    ///clase estática es un tipo de clase que no se puede instanciar
    ///Métodos, propiedades y campos dentro de una clase estática deben declararse como static.
    ///</summary>

    /// <summary>
    /// Clase estática que implementa métodos de extensión para mapear la entidad 
    /// <see cref="Experience"/> a diferentes DTOs de detalle, información básica,
    /// institución, documentos y criterios.
    /// </summary>
    public static class ExperienceDetailExtensions
    {




        /// <summary>
        /// Convierte una entidad <see cref="Experience"/> en un objeto <see cref="ExperienceDetailRequest"/>.
        /// Incluye la información de la experiencia, institución asociada, documentos y criterios evaluados.
        /// </summary>
        /// <param name="experience">La entidad <see cref="Experience"/> a mapear.</param>
        /// <returns>Un objeto <see cref="ExperienceDetailDTO"/> con la información estructurada.</returns>
        public static ExperienceDetailRequest ToDetailRequest(this Experience experience)
        {
            return new ExperienceDetailRequest
            {
                ExperienceId = experience.Id,
                ExperienceInfo = experience.ToExperienceInfoRequest(),
                InstitutionInfo = experience.Institution?.ToInstitutionRequest() ?? new InstitutionInfoRequest(),
                DocumentInfo = experience.Documents?.ToDocumentDTOs() ?? new List<DocumentDetailRequest>(),
                CriteriasDetail = experience.Evaluations.ToCriteriaDTOs()

            };
        }

        /// <summary>
        /// Convierte los datos básicos de la experiencia a un objeto <see cref="ExperienceInfoDTO"/>.
        /// Incluye nombre, tiempo de desarrollo, primer líder y resultado de la última evaluación.
        /// </summary>
        /// <param name="experience">La experiencia a mapear.</param>
        /// <returns>Un objeto <see cref="ExperienceInfoDTO"/>.</returns>
        public static ExperienceInfoRequest ToExperienceInfoRequest(this Experience experience)
        {
            return new ExperienceInfoRequest
            {
                NameExperiences = experience.NameExperiences,
                Developmenttime = experience.Developmenttime,
                StateExperienceId= experience.StateExperienceId,
                
              


                Leaders = experience.Leaders?
                .Select(l => new LeaderDetailRequest {  NameLeaders = l.NameLeaders}) 
                .ToList() ?? new List<LeaderDetailRequest>(),


                // Se toma el resultado de la última evaluación si existe,.
                EvaluationResult = experience.Evaluations != null && experience.Evaluations.Any()
                ? experience.Evaluations
                .OrderByDescending(e => e.CreatedAt) .First()  .EvaluationResult
              : experience.StateExperience != null ? experience.StateExperience.Name   // Muestra el nombre del estado escogido
               : "Sin Evaluacion"

            };
        }

        /// <summary>
        /// Convierte una entidad <see cref="Institution"/> en un objeto <see cref="InstitutionInfoRequest"/>.
        /// Incluye nombre, departamento, municipio y código DANE.
        /// </summary>
        /// <param name="institution">La institución a mapear.</param>
        /// <returns>Un objeto <see cref="InstitutionInfoRequest"/>.</returns>
        public static InstitutionInfoRequest ToInstitutionRequest(this Institution institution)
        {
            return new InstitutionInfoRequest
            {
                Name = institution.Name ?? string.Empty,
                CodeDane = institution.CodeDane ?? string.Empty,

                Departamentes = institution.Departaments?
            .Select(d => new DepartamentInfoRequest {  Name = d.Name })
            .ToList() ?? new List<DepartamentInfoRequest>(),

                Municipalities = institution.Municipalitis?
            .Select(m => new MunicipalityInfoRequest {  Name = m.Name })
            .ToList() ?? new List<MunicipalityInfoRequest>(),

            };
        }



        /// <summary>
        /// Convierte una colección de documentos en una lista de <see cref="DocumentInfoRequest"/>.
        /// Incluye las URLs de los PDFs y enlaces relacionados.
        /// </summary>
        /// <param name="documents">Colección de documentos asociados a la experiencia.</param>
        /// <returns>Lista de objetos <see cref="DocumentInfoRequest"/>.</returns>
        public static List<DocumentDetailRequest> ToDocumentDTOs(this ICollection<Document> documents)
        {
            return documents.Select(d => new DocumentDetailRequest
            {
             
                UrlLink = d.UrlLink,
                UrlPdf = d.UrlPdf,
                UrlPdfExperience = d.UrlPdfExperience                               


            }).ToList();
        }

        /// <summary>
        /// Convierte la colección de evaluaciones de una experiencia en una lista de criterios únicos.
        /// Toma los nombres de los criterios evaluados en cada evaluación.
        /// </summary>
        /// <param name="evaluations">Colección de evaluaciones asociadas a la experiencia.</param>
        /// <returns>Lista de criterios únicos representados por <see cref="CriteriaDetailRequest"/>.</returns>
        public static List<CriteriaDetailRequest> ToCriteriaDTOs(this ICollection<Evaluation> evaluations)
        {
            return evaluations
                .SelectMany(ev => ev.EvaluationCriterias) // aplanamos criterios de todas las evaluaciones
                .Where(ec => ec.Criteria != null)         // filtramos criterios válidos
                .Select(ec => new CriteriaDetailRequest
                {
                    Name = ec.Criteria!.Name
                })
                .DistinctBy(c => c.Name) // eliminamos duplicados por nombre
                .ToList();
        }
    }
}

