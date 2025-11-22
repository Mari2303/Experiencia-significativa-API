using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleSegurity;

namespace Service.Interfaces.IModuleBaseService
{
    /// <summary>
    /// Define un contrato para servicios auxiliares que operan sobre un modelo 
    /// y su correspondiente Objeto de Transferencia de Datos (DTO).
    /// </summary>
    /// <typeparam name="T">El tipo de modelo, que debe heredar de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">El tipo de DTO, que debe heredar de <see cref="BaseDTO"/>.</typeparam>
    public interface IHelperService<T, D>
        where T : BaseModel
        where D : BaseDTO
    {
        /// <summary>
        /// Valida las relaciones asociadas a una entidad específica identificada por su ID.
        /// </summary>
        /// <param name="id">El identificador único de la entidad cuyas relaciones deben validarse.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. El resultado contiene <c>true</c> si las relaciones son válidas; 
        /// de lo contrario, <c>false</c>.
        /// </returns>
        Task<bool> ValidateEntityRelationships(int id);

        /// <summary>
        /// Genera un código consecutivo basado en la cantidad de registros en la tabla del modelo asociado.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. El resultado contiene el código consecutivo generado, 
        /// formateado como una cadena de 4 dígitos (por ejemplo, "0001", "0002").
        /// </returns>
        Task<string> GenerateConsecutiveCode();

        /// <summary>
        /// Obtiene una lista de pares clave-valor que representan los valores de un tipo de enumeración especificado.
        /// </summary>
        /// <param name="enumName">
        /// El nombre del enumerador definido en el espacio de nombres <c>Entity.Models</c> (por ejemplo, "DocumentType").
        /// </param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. El resultado contiene una lista de objetos 
        /// <see cref="DataSelectRequest"/>, donde cada elemento incluye el valor numérico (<c>Id</c>) 
        /// y su descripción asociada (<c>DisplayText</c>).
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Se lanza cuando el nombre del enumerador no corresponde a un tipo de enumeración válido.
        /// </exception>
        Task<List<DataSelectRequest>> GetEnum(string enumName);
    }
}

