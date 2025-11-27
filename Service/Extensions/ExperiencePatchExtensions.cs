using Entity.Models.ModuleGeographic;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityUpdateRequest;

namespace Service.Extensions
{
    public static class ExperiencePatchExtensions
    {
        static bool HasValue(string? s) => !string.IsNullOrWhiteSpace(s);
        static bool HasList<T>(IEnumerable<T>? list) => list != null && list.Any();
        static bool HasNumber(int? n) => n.HasValue && n.Value > 0;

        public static void ApplyPatch(this Experience experience, ExperienceUpdateRequest request)
        {
            if (experience == null || request == null) return;

            
            if (HasValue(request.NameExperiences))
                experience.NameExperiences = request.NameExperiences!;

            if (HasValue(request.Code))
                experience.Code = request.Code!;

            if (HasValue(request.ThematicLocation))
                experience.ThematicLocation = request.ThematicLocation!;

            if (HasValue(request.Developmenttime))
                experience.Developmenttime = request.Developmenttime!;

            if (HasValue(request.Recognition))
                experience.Recognition = request.Recognition!;

            if (HasValue(request.Socialization))
                experience.Socialization = request.Socialization!;

            if (HasNumber(request.StateExperienceId))
                experience.StateExperienceId = request.StateExperienceId!.Value;

            // ---------- LEADERS (parcial, no borrar) ----------
            if (HasList(request.Leaders))
            {
                foreach (var l in request.Leaders!)
                {
                    // usar IdentityDocument como llave natural, si viene
                    var existing = !string.IsNullOrWhiteSpace(l.IdentityDocument)
                        ? experience.Leaders.FirstOrDefault(x => x.IdentityDocument == l.IdentityDocument)
                        : null;

                    if (existing != null)
                    {
                        if (HasValue(l.NameLeaders)) existing.NameLeaders = l.NameLeaders!;
                        if (HasValue(l.Email)) existing.Email = l.Email!;
                        if (l.Phone.HasValue) existing.Phone = l.Phone.Value;
                        if (HasValue(l.Position)) existing.Position = l.Position!;
                    }
                    else
                    {
                        // solo agregar si trae al menos un valor relevante
                        if (HasValue(l.NameLeaders) || HasValue(l.IdentityDocument) || l.Phone.HasValue)
                        {
                            experience.Leaders.Add(new Leader
                            {
                                NameLeaders = l.NameLeaders,
                                IdentityDocument = l.IdentityDocument,
                                Email = l.Email,
                                Phone = l.Phone ?? 0,
                                Position = l.Position
                            });
                        }
                    }
                }
            }

            
            if (request.InstitutionUpdate != null)
            {
                if (experience.Institution == null) experience.Institution = new Institution();

                var inst = request.InstitutionUpdate;
                if (HasValue(inst.Name)) experience.Institution.Name = inst.Name!;
                if (HasValue(inst.CodeDane)) experience.Institution.CodeDane = inst.CodeDane!;
                if (HasValue(inst.NameRector)) experience.Institution.NameRector = inst.NameRector!;
                if (HasValue(inst.EmailInstitucional)) experience.Institution.EmailInstitucional = inst.EmailInstitucional!;
                if (HasValue(inst.Caracteristic)) experience.Institution.Caracteristic = inst.Caracteristic!;
                if (HasValue(inst.TerritorialEntity)) experience.Institution.TerritorialEntity = inst.TerritorialEntity!;
                if (HasValue(inst.TestsKnow)) experience.Institution.TestsKnow = inst.TestsKnow!;
                if (HasValue(inst.Address)) experience.Institution.Address = inst.Address!;

                if (HasList(inst.Departaments))
                {
                    foreach (var d in inst.Departaments!)
                        if (!experience.Institution.Departaments.Any(x => x.Name == d.Name))
                            experience.Institution.Departaments.Add(new Departament { Name = d.Name });
                }

                if (HasList(inst.Municipalities))
                {
                    foreach (var m in inst.Municipalities!)
                        if (!experience.Institution.Municipalitis.Any(x => x.Name == m.Name))
                            experience.Institution.Municipalitis.Add(new Municipality { Name = m.Name });
                }

                if (HasList(inst.Communes))
                {
                    foreach (var c in inst.Communes!)
                        if (!experience.Institution.Communes.Any(x => x.Name == c.Name))
                            experience.Institution.Communes.Add(new Commune { Name = c.Name });
                }

                if (HasList(inst.EEZones))
                {
                    foreach (var z in inst.EEZones!)
                        if (!experience.Institution.EEZones.Any(x => x.Name == z.Name))
                            experience.Institution.EEZones.Add(new EEZone { Name = z.Name });
                }
            }

          
            if (HasList(request.DocumentsUpdate))
            {
                foreach (var d in request.DocumentsUpdate!)
                {
                    var existing = experience.Documents.FirstOrDefault(x => x.Name == d.Name);
                    if (existing != null)
                    {
                        if (HasValue(d.UrlLink)) existing.UrlLink = d.UrlLink!;
                        if (HasValue(d.UrlPdf)) existing.UrlPdf = d.UrlPdf!;
                        if (HasValue(d.UrlPdfExperience)) existing.UrlPdfExperience = d.UrlPdfExperience!;
                    }
                    else
                    {
                        // agregar solo si trae algo relevante
                        if (HasValue(d.Name))
                        {
                            experience.Documents.Add(new Document
                            {
                                Name = d.Name,
                                UrlLink = d.UrlLink,
                                UrlPdf = d.UrlPdf,
                                UrlPdfExperience = d.UrlPdfExperience
                            });
                        }
                    }
                }
            }

          
            if (HasList(request.ThematicLineIds))
            {
                foreach (var id in request.ThematicLineIds!)
                {
                    if (id <= 0) continue;
                    if (!experience.ExperienceLineThematics.Any(x => x.LineThematicId == id))
                    {
                        experience.ExperienceLineThematics.Add(new ExperienceLineThematic
                        {
                            LineThematicId = id,
                            State = true,
                            CreatedAt = DateTime.UtcNow
                        });
                    }
                }
            }

           
            if (HasList(request.GradesUpdate))
            {
                foreach (var g in request.GradesUpdate!)
                {
                    if (g.Id <= 0) continue;

                    var existing = experience.ExperienceGrades.FirstOrDefault(x => x.GradeId == g.Id);
                    if (existing != null)
                    {
                        if (HasValue(g.Description)) existing.Description = g.Description!;
                    }
                    else
                    {
                        experience.ExperienceGrades.Add(new ExperienceGrade
                        {
                            GradeId = g.Id,
                            Description = g.Description,
                            State = true,
                            CreatedAt = DateTime.UtcNow
                        });
                    }
                }
            }

           
            if (HasList(request.PopulationGradeIds))
            {
                foreach (var id in request.PopulationGradeIds!)
                {
                    if (id <= 0) continue;
                    if (!experience.ExperiencePopulations.Any(x => x.PopulationGradeId == id))
                    {
                        experience.ExperiencePopulations.Add(new ExperiencePopulation
                        {
                            PopulationGradeId = id,
                            State = true,
                            CreatedAt = DateTime.UtcNow
                        });
                    }
                }
            }

          
            if (HasList(request.ObjectivesUpdate))
            {
                foreach (var o in request.ObjectivesUpdate!)
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
                    // soportes y monitoreos si vienen
                    if (HasList(o.SupportInformationsUpdate))
                        obj.SupportInformations = o.SupportInformationsUpdate!.Select(s => new SupportInformation
                        {
                            MetaphoricalPhrase = s.MetaphoricalPhrase,
                            Testimony = s.Testimony,
                            FollowEvaluation = s.FollowEvaluation
                        }).ToList();

                    if (HasList(o.MonitoringsUpdate))
                        obj.Monitorings = o.MonitoringsUpdate!.Select(m => new Monitoring
                        {
                            MonitoringEvaluation = m.MonitoringEvaluation,
                            Sustainability = m.Sustainability,
                            Tranfer = m.Tranfer,
                            Result = m.Result
                        }).ToList();

                    experience.Objectives.Add(obj);
                }
            }

            if (HasList(request.DevelopmentsUpdate))
            {
                foreach (var d in request.DevelopmentsUpdate!)
                    experience.Developments.Add(new Development
                    {
                        CrossCuttingProject = d.CrossCuttingProject,
                        Population = d.Population,
                        PedagogicalStrategies = d.PedagogicalStrategies,
                        Coverage = d.Coverage,
                        CovidPandemic = d.CovidPandemic
                    });
            }

            if (HasList(request.HistoryExperiencesUpdate))
            {
                foreach (var h in request.HistoryExperiencesUpdate!)
                    experience.HistoryExperiences.Add(new HistoryExperience
                    {
                        Action = h.Action,
                        TableName = h.TableName,
                        UserId = h.UserId,
                        CreatedAt = DateTime.UtcNow
                    });
            }
        }
    }
}








