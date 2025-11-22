using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Helper
{
    /// <summary>
    /// Clase base abstracta para repositorios helper que proporciona un contrato para validar las relaciones de las entidades.
    /// Implementa la interfaz <see cref="IHelper{T, D}"/>.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad, que hereda de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">El tipo de Data Transfer Object (DTO), que hereda de <see cref="BaseDTO"/>.</typeparam>
    public abstract class AHelper<T, D> : IHelper<T, D>
        where T : BaseModel
        where D : BaseDTO
    {
        /// <summary>
        /// Cuando se implementa en una clase derivada, valida las relaciones de la entidad identificada por el ID especificado.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a validar.</param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado de la tarea contiene 
        /// <c>true</c> si las relaciones son válidas; de lo contrario, <c>false</c>.
        /// </returns>
        public abstract Task<bool> ValidateEntityRelationships(int id);

        /// <summary>
        /// Cuando se implementa en una clase derivada, genera un código consecutivo basado en el número de registros en la tabla del modelo asociado.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado contiene el código consecutivo generado, formateado como una cadena de 4 dígitos (por ejemplo, "0001", "0002").
        /// </returns>
        public abstract Task<string> GenerateConsecutiveCode();

        /// <summary>
        /// Cuando se implementa en una clase derivada, obtiene la representación clave-valor del enumerado especificado.
        /// El método devuelve una lista de <see cref="DataSelectRequest"/>, donde cada elemento contiene el valor numérico (Id) y su descripción correspondiente (DisplayText).
        /// </summary>
        /// <param name="enumName">El nombre del enumerado definido en el espacio de nombres <c>Entity.Models</c>.</param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado de la tarea contiene una lista de pares clave-valor que representan los valores del enum y sus descripciones.
        /// </returns>
        /// <exception cref="ArgumentException">Se lanza cuando el <paramref name="enumName"/> proporcionado no corresponde a un enum válido.</exception>
        public abstract Task<List<DataSelectRequest>> GetEnum(string enumName);

        /// <summary>
        /// Cuando se implementa en una clase derivada, valida los datos importados del DTO proporcionado.
        /// </summary>
        /// <param name="request">El DTO que contiene los datos a validar.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado indica si los datos son válidos (<c>true</c>) o no (<c>false</c>).</returns>
        public abstract Task<bool> ValidateDataImport(D request);
    }
}
