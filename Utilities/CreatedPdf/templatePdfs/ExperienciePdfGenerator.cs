using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using Entity.Models.ModuleOperation;
using Document = QuestPDF.Fluent.Document;

public static class ExperiencePdfGenerator
{
    public static byte[] Generate(Experience data, byte[]? watermarkBytes = null)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        var mainColor = "#333333";
        var softGray = "#555555";
        var lineGray = "#DDDDDD";

        // Si watermarkBytes viene null → usar arreglo vacío
        watermarkBytes ??= Array.Empty<byte>();

        // Intentar aplicar opacidad solo si hay bytes
        byte[] fadedLogo = Array.Empty<byte>();
        if (watermarkBytes.Length > 0)
        {
            fadedLogo = ApplyImageOpacitySimple(watermarkBytes, 0.08f);
        }

        var pdf = Document.Create(container =>
        {
          
            // PORTADA PROFESIONAL
           
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(0);

                // Marca de agua grande y suave
                if (fadedLogo.Length > 0)
                {
                    page.Background().Element(e =>
                    {
                        e.AlignCenter()
                         .AlignMiddle()
                         .Image(fadedLogo)
                         .FitWidth();
                    });
                }

                page.Content().Padding(40).Column(col =>
                {
                    col.Spacing(30);

                    // LOGO SUPERIOR CENTRADO
                    if (watermarkBytes.Length > 0)
                    {
                        col.Item()
                           .AlignCenter()
                           .Width(150)
                           .Image(watermarkBytes)
                           .FitWidth();
                    }

                    // TÍTULO GRANDE
                    col.Item().Text(data.NameExperiences ?? "")
                        .FontSize(36).Bold()
                        .FontColor(mainColor)
                        .AlignCenter();

                    // SUBTÍTULO INSTITUCIÓN
                    col.Item().Text(data.Institution?.Name ?? "")
                        .FontSize(20)
                        .FontColor(softGray)
                        .AlignCenter();

                    // USUARIO / AUTOR
                    col.Item().Text(data.User?.Person?.FirstName ?? data.User?.Username ?? "")
                        .FontSize(18)
                        .FontColor(softGray)
                        .AlignCenter();

                    // FECHA
                    col.Item().Text(data.CreatedAt.ToString("yyyy-MM-dd"))
                        .FontSize(16)
                        .FontColor(softGray)
                        .AlignCenter();
                });
            });

           
            container.Page(page =>
            {
                page.Margin(40);

                // Header
                page.Header().PaddingBottom(15).Row(r =>
                {
                    r.RelativeColumn().Text("Sistema de Experiencias Significativas")
                        .FontSize(10).FontColor(softGray);

                    r.RelativeColumn().AlignRight().Text("Versión 2 - 2025")
                        .FontSize(10).FontColor(softGray);
                });

                page.Content().Column(col =>
                {
                col.Spacing(20);


                SectionTitle(col, "1. Introducción");

                col.Item().Text(
                    "La presente guía tiene como propósito orientar el proceso de sistematización..."
                ).FontSize(11).LineHeight(1.4f);


                SectionTitle(col, "2. Experiencia Significativa");

                Field(col, "Nombre de la Experiencia Significativa", data.NameExperiences);
                Field(col, "Estado de desarrollo en el que se encuentra la Experiencia Significativa", data.StateExperience?.Name);
                Field(col, "Área principal que se desarrolla", data.ThematicLocation);
                Field(col, "Tiempo de desarrollo", data.Developmenttime.ToString("yyyy-MM-dd"));


                // ENFOQUE TEMÁTICO
                var enfoques = data.ExperienceLineThematics?
                    .Select(x => x.LineThematic?.Name)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();

                Field(col, "Enfoque temático de la Experiencia Significativa",
                    enfoques != null && enfoques.Count > 0
                    ? string.Join(", ", enfoques)
                    : "No disponible");


                // GRADOS
                var grados = data.ExperienceGrades?
                    .Select(x => $"{x.Description} {(x.Grade != null ? $"({x.Grade.Name})" : "")}")
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();

                Field(col, "Grados",
                    grados != null && grados.Count > 0
                    ? string.Join(", ", grados)
                    : "No registrados");


                // GRUPO POBLACIONAL
                var poblaciones = data.ExperiencePopulations?
                    .Select(x => x.PopulationGrade?.Name)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();

                Field(col, "Grupo poblacional",
                    poblaciones != null && poblaciones.Count > 0
                    ? string.Join(", ", poblaciones)
                    : "No registrado");



                SectionTitle(col, "3. Desarrollo de la Experiencia");
                    var dev = data.Developments?.FirstOrDefault();
                if (dev != null)
                {
                    Field(col, "Técnicas en articulación con el SENA vinculadas", dev.CrossCuttingProject);
                    Field(col, "El modelo educativo en el que se enmarca  el desarrollo", dev.Population);
                    Field(col, "Recibió apoyo para la formulación, fundamentación y/o desarrollo", dev.PedagogicalStrategies);
                    Field(col, "Vinculada en el Proyecto Educativo Institucional", dev.Coverage);
                   
                    }
                    Field(col, "Reconocimiento de la Experiencia Significativo", data.Recognition);
                    Field(col, "La Experiencia Significativa cuenta con", data.Socialization);





                    SectionTitle(col, "4. Identificación Institucional");

                    var inst = data.Institution;
                    if (inst != null)
                    {
                        Field(col, "Nombre", inst.Name);
                        Field(col, "Dirección", inst.Address);
                        Field(col, "Teléfono", inst.Phone.ToString());
                        Field(col, "Email", inst.EmailInstitucional);
                        Field(col, "Código DANE", inst.CodeDane);
                        Field(col, "Rector(a)", inst.NameRector);
                        Field(col, "Características del EE", inst.TerritorialEntity);
                        Field(col, "Entidad Territorial Certificada (ETC)", inst.TestsKnow);
                        Field(col, "Departamento", inst.Departaments?.FirstOrDefault()?.Name ??"");
                        Field(col, "Municipio", inst.Municipalitis?.FirstOrDefault()?.Name ?? "");
                        Field(col, "Zona", inst.EEZones?.FirstOrDefault()?.Name ?? "");
                    }


                    // datos del lider 
                    SectionTitle(col, "5. Datos Líder de la Experiencia Significativa ");
                    var leader = data.Leaders?.FirstOrDefault();
                    if (leader != null)
                    {

                        Field(col,"Líder de la Experiencia Significativa", leader.NameLeaders);
                        Field(col, "Número de identificación del Docente líder", leader.IdentityDocument);
                        Field(col, "Correo electrónico en minúscula", leader.Email);
                        Field(col, "Número de Contacto", leader.Phone.ToString());
                        Field(col, "Tipo de vinculación", leader.Position);


                    }

                    // identificacion de la experiencia (objectivos)
                    SectionTitle(col, "6. Fundamentación Teórica y Metodológica ");
                    var obj = data.Objectives?.FirstOrDefault();
                    if (obj != null)
                    {

                        Field(col, "Descripción del problema", obj.DescriptionProblem);
                        Field(col, "Objetivo propuesto", obj.ObjectiveExperience);
                        Field(col, "Logros obtenidos de acuerdo con el (o los) objetivo (s) planteado (s)", obj.EnfoqueExperience);
                        Field(col, "Productos que ha generado la Experiencia Significativa", obj.Methodologias);
                        Field(col, "¿Existe una articulación de los referentes pedagógicos , conceptuales y metodológicos que guían la Experiencia Significativa con los componentes del PEI y su proyección en el PMI?", obj.Pmi);
                        Field(col, "¿Existe coherencia de la Experiencia Significativa con el contexto donde se desarrolla y se evidencia acciones que ofrecen respuesta a las necesidades y al desarrollo integral de los NNAJ?", obj.Nnaj);
                        Field(col, "¿Cuenta con resultados a nivel de logros obtenidos  de acuerdo con los objetivos propuestos, al impacto y alternativas de solución a las problemáticas identificadas?", obj.InnovationExperience);

                    }

                    // Testimonios / soporte
                    SectionTitle(col, " ");
                    var support = obj.SupportInformations?.FirstOrDefault();
                    if (obj != null)
                     {
                        Field(col, "¿Durante el desarrollo de la Experiencia Significativa se evidencio reorganización y actualización permanente desde el análisis de la implementación, nuevos conocimientos, comprensiones, enfoques y métodos que contribuyen al mejoramiento de la práctica pedagógica?", support.Summary);
                        Field(col, "¿Existe un nivel alto de empoderamiento, participación y apropiación por parte de toda la comunidad educativa?", support.MetaphoricalPhrase);
                        Field(col, "¿Cuenta con acciones, recursos tecnológicos o no tecnológicos, materiales, métodos, contenidos entre otros novedosos para su desarrollo?", support.Testimony);
                        Field(col, "¿La Experiencia Significativa cuenta con estrategias y procesos que garantizan la permanencia y mejora continua?", support.FollowEvaluation);

                    }

                    // monitoreos 
                    SectionTitle(col, "");
                    var monito = obj.Monitorings?.FirstOrDefault();
                    if (obj != null)
                    {
                        Field(col, "¿Existen metodologías o mecanismos que sirven de referencia para replicar la Experiencia Significativa en otros escenarios?", monito.MonitoringEvaluation);
                        Field(col, "¿Cuenta con mecanismos para el seguimiento y evaluación de la implementación de la Experiencia Significativa?", monito.Sustainability);
                    }


                    SectionTitle(col, "7. Enlaces Solicitados");

                    foreach (var d in data.Documents ?? Enumerable.Empty<Entity.Models.ModuleOperation.Document>())
                    {
                        col.Item().Border(1).BorderColor(lineGray).Padding(10).Column(t =>
                        {
                            t.Spacing(5);

                            t.Item().Text($"Documento: {d.Name}")
                                .FontSize(12).Bold().FontColor(mainColor);

                            t.Item().LineHorizontal(0.5f).LineColor(lineGray);

                            t.Item().Text(d.UrlLink ?? "—")
                                .FontSize(11)
                                .FontColor("#0066CC")
                                .Underline();
                        });
                    }
                });

              
                page.Footer().AlignCenter().Text("Sistema de Experiencias Significativas © 2025")
                    .FontColor(softGray).FontSize(10);
            });
        });

        return pdf.GeneratePdf();
    }

  

    static void SectionTitle(ColumnDescriptor col, string title)
    {
        col.Item()
           .PaddingBottom(5)
           .Text(title)
               .FontSize(16)
               .Bold()
               .FontColor("#333333");
    }

    static void Field(ColumnDescriptor col, string label, string? value)
    {
        col.Item().PaddingBottom(10).Column(c =>
        {
            c.Item().Text(label + ":").Bold().FontColor("#333333").FontSize(12);
            c.Item().Text(string.IsNullOrWhiteSpace(value) ? "—" : value)
                .FontSize(11).FontColor("#555555").LineHeight(1.4f);
        });
    }

    // Marca de agua suave
    public static byte[] ApplyImageOpacitySimple(byte[] imageBytes, float opacity)
    {
        using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageBytes);
        image.Mutate(ctx => ctx.Opacity(opacity));
        using var ms = new MemoryStream();
        image.Save(ms, new PngEncoder());
        return ms.ToArray();
    }

    // Cargar imagen desde URL — método SEGURO
    public static async Task<byte[]> LoadImageFromUrlSafeAsync(string imageUrl)
    {
        try
        {
            using var http = new HttpClient();
            return await http.GetByteArrayAsync(imageUrl);
        }
        catch
        {
            return Array.Empty<byte>(); // nunca null
        }
    }
}









