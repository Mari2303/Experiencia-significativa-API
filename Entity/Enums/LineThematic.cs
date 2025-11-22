using System.ComponentModel;

namespace Entity.Models.Enums
{
    public enum LineThematic
    {
        [Description("Ciencia y Tecnología")]
        CienciaYTecnologia = 1,

        [Description("Educación Ambiental")]
        EducacionAmbiental = 2,

        [Description("Interculturalidad Bilingüismo")]
        InterculturalidadBilinguismo = 3,

        [Description("Arte, Cultura y Patrimonio")]
        ArteCulturaYPatrimonio = 4,

        [Description("Habilidades Comunicativas")]
        HabilidadesComunicativas = 5,

        [Description("Academica Curricular")]
        AcademicaCurricular = 6,

        [Description("Inclusion Diversidad")]
        InclusionDiversidad = 7,

        [Description("Convivencia Escolar (Ciencias Sociales y Políticas)")]
        ConvivenciaEscolar = 8,

        [Description("Danza, Deporte y Recreación")]
        DanzaDeporteYRecreacion = 9
    }
}
