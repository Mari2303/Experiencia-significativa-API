using AutoMapper;
using Entity.Dtos.ModuleBase;
using Entity.Enums;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces;
using Utilities.Helper;

namespace Service.Implementations.ModuleBaseService
{
    /// <summary>
    /// Implementación concreta del servicio auxiliar abstracto que maneja operaciones de entidades 
    /// y delega la lógica de validación a la capa de repositorio.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad, que hereda de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">El tipo de Data Transfer Object (DTO), que hereda de <see cref="BaseDTO"/>.</typeparam>
    public class HelperService<T, D> : AHelperService<T, D>
        where T : BaseModel
        where D : BaseDTO
    {
        private readonly IHelper<T, D> _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelperService{T, D}"/>.
        /// </summary>
        /// <param name="repository">La instancia del repositorio responsable del acceso a datos y validación de relaciones.</param>
        /// <param name="mapper">La instancia de AutoMapper usada para convertir entre entidades y DTOs.</param>
        public HelperService(IHelper<T, D> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Valida las relaciones de la entidad especificada delegando al repositorio.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a validar.</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. 
        /// El resultado será <c>true</c> si las relaciones son válidas; de lo contrario, <c>false</c>.
        /// </returns>
        public override async Task<bool> ValidateEntityRelationships(int id)
        {
            return await _repository.ValidateEntityRelationships(id);
        }

        /// <summary>
        /// Genera un código consecutivo delegando la lógica a la capa de repositorio.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. 
        /// El resultado contiene el código consecutivo generado en formato de 4 dígitos (ejemplo: "0001", "0002").
        /// </returns>
        public override async Task<string> GenerateConsecutiveCode()
        {
            return await _repository.GenerateConsecutiveCode();
        }

        /// <summary>
        /// Obtiene una lista de pares clave-valor que representan los valores del enum especificado.
        /// Utiliza reflexión para localizar el enum por nombre en el namespace <c>Entity.Models</c> 
        /// y extrae su valor numérico junto con la descripción asociada en <see cref="DescriptionAttribute"/>.
        /// </summary>
        /// <param name="enumName">El nombre del enum a recuperar, como "DocumentType" o "Gender".</param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. 
        /// El resultado es una lista de <see cref="DataSelectRequest"/> que contiene el valor del enum (como <c>Id</c>) y su descripción (como <c>DisplayText</c>).
        /// </returns>
        /// <exception cref="ArgumentException">Se lanza si el tipo de enum no se encuentra o no es válido.</exception>
        public override async Task<List<DataSelectRequest>> GetEnum(string enumName)
        {
            return await _repository.GetEnum(enumName);
        }
    }
}

