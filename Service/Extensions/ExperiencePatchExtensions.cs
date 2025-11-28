using Entity.Models.ModuleGeographic;
using Entity.Models.ModuleOperation;
using Entity.Requests.EntityData.EntityUpdateRequest;

public static class ExperiencePatchExtensions
{
    public static void ApplyPatch(this Experience experience, ExperienceUpdateRequest request)
    {
        if (experience == null || request == null)
            return;

        // =======================
        // CAMPOS BÁSICOS
        // =======================
        if (request.NameExperiences != null)
            experience.NameExperiences = request.NameExperiences;

        if (request.Code != null)
            experience.Code = request.Code;

        if (request.ThematicLocation != null)
            experience.ThematicLocation = request.ThematicLocation;

        if (request.Developmenttime.HasValue)
            experience.Developmenttime = request.Developmenttime.Value;

        if (request.Recognition != null)
            experience.Recognition = request.Recognition;

        if (request.Socialization != null)
            experience.Socialization = request.Socialization;

        if (request.StateExperienceId.HasValue && request.StateExperienceId.Value > 0)
            experience.StateExperienceId = request.StateExperienceId.Value;


        // =======================
        // LÍDERES (PATCH REAL)
        // =======================
        if (request.Leaders != null)
        {
            foreach (var l in request.Leaders)
            {
                var existing = experience.Leaders
                    .FirstOrDefault(x => x.IdentityDocument == l.IdentityDocument);

                if (existing != null)
                {
                    if (l.NameLeaders != null) existing.NameLeaders = l.NameLeaders;
                    if (l.Email != null) existing.Email = l.Email;
                    if (l.Phone != 0) existing.Phone = l.Phone;
                    if (l.Position != null) existing.Position = l.Position;
                }
                else
                {
                    experience.Leaders.Add(new Leader
                    {
                        NameLeaders = l.NameLeaders,
                        IdentityDocument = l.IdentityDocument,
                        Email = l.Email,
                        Phone = l.Phone,
                        Position = l.Position
                    });
                }
            }
        }


        // =======================
        // INSTITUCIÓN (PATCH REAL)
        // =======================
        if (request.InstitutionUpdate != null)
        {
            if (experience.Institution == null)
                experience.Institution = new Institution();

            var inst = request.InstitutionUpdate;

            if (inst.Name != null) experience.Institution.Name = inst.Name;
            if (inst.CodeDane != null) experience.Institution.CodeDane = inst.CodeDane;
            if (inst.NameRector != null) experience.Institution.NameRector = inst.NameRector;
            if (inst.EmailInstitucional != null) experience.Institution.EmailInstitucional = inst.EmailInstitucional;
            if (inst.Caracteristic != null) experience.Institution.Caracteristic = inst.Caracteristic;
            if (inst.TerritorialEntity != null) experience.Institution.TerritorialEntity = inst.TerritorialEntity;
            if (inst.TestsKnow != null) experience.Institution.TestsKnow = inst.TestsKnow;
            if (inst.Address != null) experience.Institution.Address = inst.Address;

            // Departamentos agregados, no reemplazados
            if (inst.Departaments != null)
            {
                foreach (var d in inst.Departaments)
                {
                    if (!experience.Institution.Departaments.Any(x => x.Name == d.Name))
                        experience.Institution.Departaments.Add(new Departament { Name = d.Name });
                }
            }

            // Municipios
            if (inst.Municipalities != null)
            {
                foreach (var m in inst.Municipalities)
                {
                    if (!experience.Institution.Municipalitis.Any(x => x.Name == m.Name))
                        experience.Institution.Municipalitis.Add(new Municipality { Name = m.Name });
                }
            }

            // Comunas
            if (inst.Communes != null)
            {
                foreach (var c in inst.Communes)
                {
                    if (!experience.Institution.Communes.Any(x => x.Name == c.Name))
                        experience.Institution.Communes.Add(new Commune { Name = c.Name });
                }
            }

            // Zonas
            if (inst.EEZones != null)
            {
                foreach (var z in inst.EEZones)
                {
                    if (!experience.Institution.EEZones.Any(x => x.Name == z.Name))
                        experience.Institution.EEZones.Add(new EEZone { Name = z.Name });
                }
            }
        }


        // =======================
        // DOCUMENTOS (PATCH REAL)
        // =======================
        if (request.DocumentsUpdate != null)
        {
            foreach (var d in request.DocumentsUpdate)
            {
                var existing = experience.Documents.FirstOrDefault(x => x.Name == d.Name);

                if (existing != null)
                {
                    if (d.UrlLink != null) existing.UrlLink = d.UrlLink;
                    if (d.UrlPdf != null) existing.UrlPdf = d.UrlPdf;
                    if (d.UrlPdfExperience != null) existing.UrlPdfExperience = d.UrlPdfExperience;
                }
                else
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

        // =======================
        // LÍNEAS TEMÁTICAS
        // =======================
        if (request.ThematicLineIds != null)
        {
            foreach (var id in request.ThematicLineIds)
            {
                if (id <= 0)
                    continue;

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

        // =======================
        // GRADOS
        // =======================
        if (request.GradesUpdate != null)
        {
            foreach (var g in request.GradesUpdate)
            {
                if (g.Id <= 0)
                    continue;

                var existing = experience.ExperienceGrades
                    .FirstOrDefault(x => x.GradeId == g.Id);

                if (existing != null)
                {
                    if (!string.IsNullOrWhiteSpace(g.Description))
                        existing.Description = g.Description;
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

        // =======================
        // POBLACIONES
        // =======================
        if (request.PopulationGradeIds != null)
        {
            foreach (var id in request.PopulationGradeIds)
            {
                if (id <= 0)
                    continue;

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


        // =======================
        // HISTORIAL
        // =======================
        if (request.HistoryExperiencesUpdate != null)
        {
            foreach (var h in request.HistoryExperiencesUpdate)
            {
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







