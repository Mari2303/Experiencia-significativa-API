using Entity.Requests.EntityData.EntityDetailRequest;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Utilities.CreatedPdf.templatePdfs
{
    public static class EvaluationPdfGenerator
    {
        public static byte[] Generate(EvaluationDetailRequest evaluation, byte[]? logoBytes = null)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            // Colores más profesionales
            var primaryColor = Colors.Grey.Darken3;      // Gris oscuro elegante
            var headerColor = Colors.Grey.Darken4;       // Gris casi negro
            var softGrey = Colors.Grey.Lighten3;         // Cuadros suaves
            var tableBorder = Colors.Grey.Lighten1;      // Líneas más elegantes

            var pdf = Document.Create(container =>
            {
                // -------------------------------
                //  PÁGINA 1 – Portada profesional
                // -------------------------------
                container.Page(page =>
                {
                    page.Margin(60);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(12).FontColor(Colors.Black));

                    page.Content().AlignCenter().PaddingTop(20).Column(col =>
                    {
                        col.Spacing(25);

                        // LOGO — sin modificar
                        if (logoBytes != null)
                        {
                            col.Item().Width(100).AlignCenter()
                               .Image(logoBytes)
                               .WithCompressionQuality(ImageCompressionQuality.High);
                        }

                        // TÍTULO principal
                        col.Item().PaddingTop(10)
                            .Text("REPORTE EVALUATIVO DE LA EXPERIENCIA")
                            .FontSize(28).SemiBold()
                            .FontColor(headerColor)
                            .AlignCenter();

                        // Subtítulos con estilo más profesional
                        col.Item().PaddingTop(60)
                            .AlignCenter()
                            .Text($"Experiencia: {evaluation.ExperienceName}")
                            .FontSize(17)
                            .FontColor(primaryColor);

                        col.Item().PaddingTop(30)
                            .AlignCenter()
                            .Text($"Institución Educativa: {evaluation.InstitutionName}")
                            .FontSize(16);

                        col.Item().PaddingTop(30)
                            .AlignCenter()
                            .Text($"Tipo de Evaluación: {evaluation.TypeEvaluation}")
                            .FontSize(16);

                        col.Item().PaddingTop(120)
                            .AlignCenter()
                            .Text($"Generado el {DateTime.Now:dd 'de' MMMM 'de' yyyy}")
                            .FontColor(Colors.Grey.Darken1)
                            .Italic();
                    });

                    page.Footer().AlignCenter()
                        .Text("Documento confidencial — Sistema de Evaluación de Experiencias Significativas")
                        .FontSize(9).FontColor(Colors.Grey.Darken1).Italic();
                });


                // -------------------------------
                //  PÁGINA 2 – Contenido detallado
                // -------------------------------
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    // Marca de agua — NO SE CAMBIA
                    if (logoBytes != null)
                    {
                        var faded = ApplyImageOpacitySimple(logoBytes, 0.07f);

                        page.Background().Layers(layer =>
                        {
                            layer.PrimaryLayer()
                                .AlignCenter().AlignMiddle()
                                .Width(290).Height(290)
                                .Image(faded)
                                .WithCompressionQuality(ImageCompressionQuality.Medium);
                        });
                    }

                    // Encabezado moderno
                    page.Header()
                        .Background(headerColor)
                        .Padding(12)
                        .Row(row =>
                        {
                            row.RelativeColumn()
                                .AlignLeft()
                                .Text("Evaluación Detallada")
                                .FontSize(18)
                                .FontColor(Colors.White)
                                .Bold();

                            row.ConstantColumn(100)
                                .AlignRight()
                                .Text(DateTime.Now.ToString("dd/MM/yyyy"))
                                .FontColor(Colors.White);
                        });

                    // CONTENIDO
                    page.Content().PaddingVertical(20).Column(col =>
                    {
                        col.Spacing(15);

                        // ----------------------
                        // Información General
                        // ----------------------
                        col.Item().Background(softGrey).Padding(8)
                            .Text("Información General")
                            .FontSize(15).SemiBold()
                            .FontColor(headerColor);

                        col.Item().PaddingLeft(8).Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.ConstantColumn(210);
                                c.RelativeColumn();
                            });

                            void Row(string label, string value)
                            {
                                table.Cell()
                                    .BorderBottom(0.25f)
                                    .BorderColor(tableBorder)
                                    .Padding(6)
                                    .Text(label).Bold().FontColor(primaryColor);

                                table.Cell()
                                    .BorderBottom(0.25f)
                                    .BorderColor(tableBorder)
                                    .Padding(6)
                                    .Text(value ?? "—");
                            }

                            Row("Tipo de Evaluación:", evaluation.TypeEvaluation);
                            Row("Rol de Acompañamiento:", evaluation.AccompanimentRole);
                            Row("Resultado Final:", evaluation.EvaluationResult);
                            Row("Experiencia:", evaluation.ExperienceName);
                            Row("Institución:", evaluation.InstitutionName);
                            Row("Comentarios:", evaluation.Comments);
                        });

                        // ----------------------
                        // Criterios
                        // ----------------------
                        col.Item().PaddingTop(15)
                            .Background(softGrey).Padding(8)
                            .Text("Criterios de Evaluación")
                            .FontSize(15).SemiBold()
                            .FontColor(headerColor);

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(1);
                                c.ConstantColumn(70);
                                c.RelativeColumn(2);
                            });

                            // Encabezados
                            table.Header(header =>
                            {
                                header.Cell().Background(primaryColor).Padding(6)
                                    .Text("Criterio").FontColor(Colors.White).Bold();

                                header.Cell().Background(primaryColor).Padding(6)
                                    .Text("Puntaje").FontColor(Colors.White).Bold();

                                header.Cell().Background(primaryColor).Padding(6)
                                    .Text("Descripción").FontColor(Colors.White).Bold();
                            });

                            foreach (var c in evaluation.CriteriaEvaluations)
                            {
                                table.Cell().BorderBottom(0.25f).BorderColor(tableBorder)
                                    .Padding(6).Text(c.Criteria).Bold();

                                table.Cell().BorderBottom(0.25f).BorderColor(tableBorder)
                                    .AlignCenter().Padding(6)
                                    .Text(c.Score.ToString());

                                table.Cell().BorderBottom(0.25f).BorderColor(tableBorder)
                                    .Padding(6).Text(c.DescriptionContribution ?? "—");
                            }
                        });

                        // ----------------------
                        // Líneas Temáticas
                        // ----------------------
                        col.Item().PaddingTop(15)
                            .Background(softGrey).Padding(8)
                            .Text("Líneas Temáticas")
                            .FontSize(15).SemiBold()
                            .FontColor(headerColor);

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(c => c.RelativeColumn());
                            foreach (var line in evaluation.ThematicLineNames)
                            {
                                table.Cell()
                                    .BorderBottom(0.25f)
                                    .BorderColor(tableBorder)
                                    .Padding(6)
                                    .Text($"• {line}");
                            }
                        });
                    });

                    page.Footer().AlignCenter().Text(txt =>
                    {
                        txt.Span("Sistema de Evaluación de Experiencias Significativas ").FontSize(9);
                        txt.Span("© 2025").FontSize(9).Bold();
                    });
                });
            });

            return pdf.GeneratePdf();
        }

        // Opacidad de imagen simple 
        public static byte[] ApplyImageOpacitySimple(byte[] imageBytes, float opacity)
        {
            using var image = SixLabors.ImageSharp.Image.Load<Rgba32>(imageBytes);
            image.Mutate(ctx => ctx.Opacity(opacity));
            using var ms = new MemoryStream();
            image.Save(ms, new PngEncoder());
            return ms.ToArray();
        }

        //  Cargar logo desde URL 
        public static async Task<byte[]?> LoadImageFromUrlAsync(string imageUrl)
        {
            using var http = new HttpClient();
            return await http.GetByteArrayAsync(imageUrl);
        }
    }
}










