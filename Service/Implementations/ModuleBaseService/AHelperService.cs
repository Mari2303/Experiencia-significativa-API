using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleSegurity;
using Service.Interfaces.IModuleBaseService;

namespace Service.Implementations.ModuleBaseService
{
    /// <summary>
    /// Clase base abstracta para servicios auxiliares que proveen operaciones genéricas de validación 
    /// y utilidades relacionadas con entidades del dominio.
    /// 
    /// Esta clase define la estructura común que deben implementar los servicios derivados, 
    /// asegurando un contrato uniforme en operaciones clave como:
    /// - Validación de relaciones entre entidades.
    /// - Generación de códigos consecutivos.
    /// - Obtención de valores de enumeraciones en formato de lista seleccionable.
    /// 
    /// Implementa la interfaz <see cref="IHelperService{T, D}"/>.
    /// </summary>
    /// <typeparam name="T">
    /// Tipo de entidad, el cual debe heredar de <see cref="BaseModel"/>.
    /// Representa el modelo principal en la base de datos.
    /// </typeparam>
    /// <typeparam name="D">
    /// Tipo de objeto de transferencia de datos (DTO), el cual debe heredar de <see cref="BaseDTO"/>.
    /// Representa la capa de transporte de información entre las entidades y la capa de aplicación/servicio.
    /// </typeparam>
    public abstract class AHelperService<T, D> : IHelperService<T, D>
        where T : BaseModel
        where D : BaseDTO
    {
        /// <summary>
        /// Valida las relaciones de la entidad asociada al identificador proporcionado.
        /// 
        /// La lógica de validación debe ser implementada en la clase derivada. 
        /// Por ejemplo, se puede verificar que la entidad no tenga dependencias activas 
        /// antes de permitir una eliminación.
        /// </summary>
        /// <param name="id">Identificador único de la entidad a validar.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado indica si las relaciones de la entidad son válidas:
        /// <c>true</c> si no existen conflictos en las relaciones, 
        /// <c>false</c> en caso contrario.
        /// </returns>
        public abstract Task<bool> ValidateEntityRelationships(int id);

        /// <summary>
        /// Genera un código consecutivo basado en la cantidad de registros existentes 
        /// en la tabla de la entidad asociada.
        /// 
        /// Este código puede ser utilizado, por ejemplo, como un identificador legible 
        /// o un número de folio secuencial.
        /// </summary>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es el código consecutivo generado, 
        /// formateado como una cadena de 4 dígitos (ejemplo: "0001", "0002", etc.).
        /// </returns>
        public abstract Task<string> GenerateConsecutiveCode();

        /// <summary>
        /// Obtiene una representación clave-valor de un tipo de enumeración definido 
        /// en el espacio de nombres <c>Entity.Models</c>.
        /// 
        /// Cada elemento de la lista representa un valor del enum con su identificador numérico (Id) 
        /// y su descripción legible (DisplayText).
        /// </summary>
        /// <param name="enumName">
        /// Nombre del tipo de enumeración a consultar. Debe coincidir con un enum válido definido en <c>Entity.Models</c>.
        /// </param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es una lista de <see cref="DataSelectRequest"/> 
        /// representando los valores del enum.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Se lanza cuando el <paramref name="enumName"/> no corresponde a un enum válido.
        /// </exception>
        public abstract Task<List<DataSelectRequest>> GetEnum(string enumName);
    }
}

