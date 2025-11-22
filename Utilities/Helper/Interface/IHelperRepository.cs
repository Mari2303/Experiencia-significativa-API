using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Helper
{
    /// <summary>
    /// Define un contrato para operaciones de repositorio relacionadas con la validación de relaciones de un tipo específico de entidad.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad, que hereda de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">El tipo de Data Transfer Object (DTO), que hereda de <see cref="BaseDTO"/>.</typeparam>
    public interface IHelper<T, D>
        where T : BaseModel
        where D : BaseDTO
    {
        /// <summary>
        /// Valida las relaciones asociadas con la entidad identificada por el ID especificado.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a validar.</param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado de la tarea es 
        /// <c>true</c> si las relaciones son válidas; de lo contrario, <c>false</c>.
        /// </returns>
        Task<bool> ValidateEntityRelationships(int id);

        /// <summary>
        /// Genera un código consecutivo basado en el número de registros en la tabla del modelo asociado.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado de la tarea contiene el código consecutivo generado, formateado como una cadena de 4 dígitos (por ejemplo, "0001", "0002").
        /// </returns>
        Task<string> GenerateConsecutiveCode();

        /// <summary>
        /// Obtiene una lista de pares clave-valor que representan los valores de un tipo de enumeración especificado.
        /// </summary>
        /// <param name="enumName">El nombre del enum definido en el espacio de nombres <c>Entity.Models</c> (por ejemplo, "DocumentType").</param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado de la tarea contiene una lista de objetos <see cref="DataSelectRequest"/>, donde cada elemento incluye el valor numérico (<c>Id</c>) y su descripción asociada (<c>DisplayText</c>).
        /// </returns>
        /// <exception cref="ArgumentException">Se lanza cuando el nombre del enum no corresponde a un tipo de enum válido.</exception>
        Task<List<DataSelectRequest>> GetEnum(string enumName);

        /// <summary>
        /// Valida los datos importados del DTO proporcionado.
        /// </summary>
        /// <param name="request">El DTO que contiene los datos a validar.</param>
        /// <returns>Una tarea que representa la operación asíncrona. Devuelve <c>true</c> si los datos son válidos, <c>false</c> en caso contrario.</returns>
        Task<bool> ValidateDataImport(D request);
    }
}

