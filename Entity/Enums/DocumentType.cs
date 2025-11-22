using System.ComponentModel;

namespace Entity.Enums
{
    /// <summary>
    /// Represents the type of documents for people
    /// </summary>
    public enum DocumentType
    {
        [Description("Cédula de ciudadanía")]
        CitizenshipId = 1,

        [Description("Cédula de extranjería")]
        ForeignerId = 2,

       

    }

}