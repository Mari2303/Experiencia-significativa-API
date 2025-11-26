using Entity.Models.ModuleGeographic;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityDataRequest;
using Entity.Requests.EntityData.EntityUpdateRequest;

namespace Service.Extensions 
{
    /// <summary>
    /// Clase estática que contiene métodos de extensión para aplicar cambios parciales (PATCH) 
    /// a la entidad <see cref="Experience"/> a partir de un objeto <see cref="ExperiencePatchDTO"/>.
    /// </summary>
    public static class ExperiencePatchExtensions
    {
        /// <summary>
        /// Aplica los cambios enviados en un <see cref="ExperiencePatchDTO"/> sobre la entidad <see cref="Experience"/>.
        /// Solo actualiza los valores que no son nulos o vacíos.
        /// </summary>
        /// <param name="experience">Entidad <see cref="Experience"/> existente en la base de datos.</param>
        /// <param name="dto">Objeto con los nuevos valores a actualizar parcialmente.</param>
        public static void ApplyPatch(this Experience experience, ExperienceUpdateRequest request)
        {
            if (experience == null || request == null)
                return;

           
            // Datos de la experiencia 
         

            if (!string.IsNullOrWhiteSpace(request.NameExperiences))
                experience.NameExperiences = request.NameExperiences;

            if (!string.IsNullOrWhiteSpace(request.Code))
                experience.Code = request.Code;

            if (!string.IsNullOrWhiteSpace(request.ThematicLocation))
                experience.ThematicLocation = request.ThematicLocation;

            if (request.Developmenttime != DateTime.MinValue)
                experience.Developmenttime = request.Developmenttime;

            if (!string.IsNullOrWhiteSpace(request.Recognition))
                experience.Recognition = request.Recognition;

            if (!string.IsNullOrWhiteSpace(request.Socialization))
                experience.Socialization = request.Socialization;

            if (request.StateExperienceId > 0)
                experience.StateExperienceId = request.StateExperienceId;


          
            // Datos de lider
           
            if (request.Leaders != null && request.Leaders.Any())
            {
                experience.Leaders = request.Leaders.Select(l => new Leader
                {
                    NameLeaders = l.NameLeaders,
                    IdentityDocument = l.IdentityDocument,
                    Email = l.Email,
                    Phone = l.Phone,
                    Position = l.Position
                }).ToList();
            }

            // Datos de institucion

            if (request.InstitutionUpdate != null)
            {
                if (experience.Institution == null)
                    experience.Institution = new Institution();

                var inst = request.InstitutionUpdate;

                if (!string.IsNullOrWhiteSpace(inst.Name))
                    experience.Institution.Name = inst.Name;

                if (!string.IsNullOrWhiteSpace(inst.CodeDane))
                    experience.Institution.CodeDane = inst.CodeDane;

                if (!string.IsNullOrWhiteSpace(inst.NameRector))
                    experience.Institution.NameRector = inst.NameRector;

                if (!string.IsNullOrWhiteSpace(inst.EmailInstitucional))
                    experience.Institution.EmailInstitucional = inst.EmailInstitucional;

                if (!string.IsNullOrWhiteSpace(inst.Caracteristic))
                    experience.Institution.Caracteristic = inst.Caracteristic;

                if (!string.IsNullOrWhiteSpace(inst.TerritorialEntity))
                    experience.Institution.TerritorialEntity = inst.TerritorialEntity;

                if (!string.IsNullOrWhiteSpace(inst.TestsKnow))
                    experience.Institution.TestsKnow = inst.TestsKnow;

                if (!string.IsNullOrWhiteSpace(inst.Address))
                    experience.Institution.Address = inst.Address;

                if (inst.Departaments != null && inst.Departaments.Any())
                {
                    experience.Institution.Departaments = inst.Departaments.Select(d =>
                        new Departament { Name = d.Name }).ToList();
                }

                if (inst.Municipalities != null && inst.Municipalities.Any())
                {
                    experience.Institution.Municipalitis = inst.Municipalities.Select(m =>
                        new Municipality { Name = m.Name }).ToList();
                }

                if (inst.Communes != null && inst.Communes.Any())
                {
                    experience.Institution.Communes = inst.Communes.Select(c =>
                        new Commune { Name = c.Name }).ToList();
                }

                if (inst.EEZones != null && inst.EEZones.Any())
                {
                    experience.Institution.EEZones = inst.EEZones.Select(z =>
                        new EEZone { Name = z.Name }).ToList();
                }






                // Documentos

                if (request.DocumentsUpdate != null && request.DocumentsUpdate.Any())
                {
                    experience.Documents = request.DocumentsUpdate.Select(d => new Document
            {
                        Name = d.Name,
                        UrlLink = d.UrlLink,
                        UrlPdf = d.UrlPdf,
                        UrlPdfExperience = d.UrlPdfExperience
                    }).ToList();
                }

                
                // Objectos y sus relaciones

                if (request.ObjectivesUpdate != null && request.ObjectivesUpdate.Any())
                {
                    experience.Objectives = request.ObjectivesUpdate.Select(o =>
                    {
                        var obj = new Objective
                        {
                            DescriptionProblem = o.DescriptionProblem,
                            ObjectiveExperience = o.ObjectiveExperience,
                            EnfoqueExperience = o.EnfoqueExperience,
                            Methodologias = o.Methodologias,
                            InnovationExperience = o.InnovationExperience,
                            Pmi = o.Pmi,
                            Nnaj = o.Nnaj,
                            CreatedAt = DateTime.UtcNow
                        };

                        if (o.SupportInformationsUpdate != null)
                {
                            obj.SupportInformations = o.SupportInformationsUpdate.Select(s => new SupportInformation
                        {
                           
                                MetaphoricalPhrase = s.MetaphoricalPhrase,
                                Testimony = s.Testimony,
                                FollowEvaluation = s.FollowEvaluation
                            }).ToList();
                        }
                            
                        if (o.MonitoringsUpdate != null)
                        {
                            obj.Monitorings = o.MonitoringsUpdate.Select(m => new Monitoring
                            {
                                MonitoringEvaluation = m.MonitoringEvaluation,
                                Sustainability = m.Sustainability,
                                Tranfer = m.Tranfer,
                                Result = m.Result
                            }).ToList();
                }

                        return obj;

                    }).ToList();
            }

           
              
                //  Desarrollo
               
                if (request.DevelopmentsUpdate != null && request.DevelopmentsUpdate.Any())
            {
                    experience.Developments = request.DevelopmentsUpdate.Select(d => new Development
                    {
                        CrossCuttingProject = d.CrossCuttingProject,
                        Population = d.Population,
                        PedagogicalStrategies = d.PedagogicalStrategies,
                        Coverage = d.Coverage,
                        CovidPandemic = d.CovidPandemic
                    }).ToList();
                }

                // Departamentos 
                if (request.InstitutionUpdate.Departaments != null && request.InstitutionUpdate.Departaments.Any())
                    experience.Institution.Departaments = request.InstitutionUpdate.Departaments
                        .Select(d => new Departament { Name = d.Name })
                        .ToList();

                // Linea tematicas

                if (request.ThematicLineIds != null && request.ThematicLineIds.Any())
                {
                    experience.ExperienceLineThematics = request.ThematicLineIds.Select(id =>
                        new ExperienceLineThematic
                        {
                            LineThematicId = id,
                            State = true,
                            CreatedAt = DateTime.UtcNow
                        }).ToList();
            }

               
                // grados
          
                if (request.GradesUpdate != null && request.GradesUpdate.Any())
            {
                    experience.ExperienceGrades = request.GradesUpdate.Select(g =>
                        new ExperienceGrade
                {
                            GradeId = g.Id,
                            Description = g.Description
                        }).ToList();
                }

               
                // poblacion

                if (request.PopulationGradeIds != null && request.PopulationGradeIds.Any())
                {
                    experience.ExperiencePopulations = request.PopulationGradeIds.Select(id =>
                        new ExperiencePopulation
                    {
                            PopulationGradeId = id,
                            State = true,
                            CreatedAt = DateTime.UtcNow
                        }).ToList();
                    }

                
                // historial
               
                if (request.HistoryExperiencesUpdate != null && request.HistoryExperiencesUpdate.Any())
                {
                    experience.HistoryExperiences = request.HistoryExperiencesUpdate.Select(h =>
                        new HistoryExperience
                        {
                            Action = h.Action,
                            TableName = h.TableName,
                            UserId = h.UserId,
                            CreatedAt = DateTime.UtcNow
                        }).ToList();
                }
            }
        }
    }
}






