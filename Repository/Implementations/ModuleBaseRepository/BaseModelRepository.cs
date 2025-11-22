using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleSegurity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Utilities.Helper;

namespace Repository.Implementations.ModuleBaseRepository
{
    /// <summary>
    /// Implementación concreta del repositorio abstracto para realizar operaciones CRUD genéricas.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad, que debe heredar de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">El tipo de objeto de transferencia de datos (DTO), que debe heredar de <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">El tipo de objeto de transferencia de datos (Request), que debe heredar de <see cref="BaseRequest"/>.</typeparam>
    public class BaseModelRepository<T, D, R> : ABaseModelRepository<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<T, D> _helperRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseModelRepository{T, D, R}"/>.
        /// </summary>
        /// <param name="context">El contexto de base de datos para acceder a los conjuntos de entidades.</param>
        /// <param name="mapper">La instancia de AutoMapper utilizada para mapear entre tipos de entidad y DTO.</param>
        public BaseModelRepository(ApplicationContext context, IMapper mapper, IConfiguration configuration, IHelper<T, D> helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }

        /// <summary>
        /// Recupera (donde State es verdadero) una lista filtrada, ordenada y paginada de DTOs basada en los filtros de consulta especificados.
        /// </summary>
        /// <param name="filters">
        /// Una instancia de <see cref="QueryFilterRequest"/> que contiene parámetros opcionales para filtrado, 
        /// ordenamiento, paginación y restricciones de claves foráneas.
        /// </param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. El resultado contiene un <see cref="IEnumerable{D}"/> 
        /// que representa la lista de DTOs mapeados que coinciden con los filtros y configuraciones de paginación aplicados.
        /// </returns>
        /// <exception cref="Exception">
        /// Lanza cualquier excepción encontrada durante la ejecución de la consulta o el mapeo de datos.
        /// </exception>
        public override async Task<IEnumerable<R>> GetAll(QueryFilterRequest filters)
        {
            int pageNumber = filters.PageNumber.HasValue && filters.PageNumber.Value > 0
                ? filters.PageNumber.Value
                : _configuration.GetValue<int>("Pagination:DefaultPageNumber");

            int pageSize = filters.PageSize.HasValue && filters.PageSize.Value > 0
                ? filters.PageSize.Value
                : _configuration.GetValue<int>("Pagination:DefaultPageSize");

            filters.ColumnOrder ??= _configuration.GetValue<string>("Ordering:DefaultColumnOrder");
            filters.DirectionOrder ??= _configuration.GetValue<string>("Ordering:DefaultDirectionOrder");

            try
            {
                IQueryable<T> query = _context.Set<T>();

                // Filtro por estado
                if (filters.OnlyState.HasValue)
                {
                    query = filters.OnlyState.Value
                        ? query.Where(x => x.State)
                        : query.Where(x => !x.State);
                }

                // Filtro por clave foránea
                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    query = query.Where(i => EF.Property<int>(i, filters.NameForeignKey) == filters.ForeignKey);
                }

                // Filtros dinámicos
                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    query = PagedListRequest<T>.ApplyDynamicFilters(query, filters);
                }

                // Ordenamiento
                query = PagedListRequest<T>.ApplyOrdering(query, filters);

                // Paginación
                if (filters.AplyPagination)
                {
                    int skip = (pageNumber - 1) * pageSize;
                    query = query.Skip(skip).Take(pageSize);
                }

                var lstModel = await query.ToListAsync();
                var lstDto = lstModel.Select(item => _mapper.Map<R>(item)).ToList();

                return lstDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al recuperar los datos: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Recupera una entidad por su identificador único.
        /// </summary>
        /// <param name="id">El ID de la entidad a recuperar.</param>
        /// <returns>Una tarea que representa la operación asincrónica, conteniendo la entidad de tipo <typeparamref name="T"/> si se encuentra; de lo contrario, null.</returns>
        public override async Task<T> GetById(int id)
        {
            try
            {
                return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al recuperar los datos: {ex.Message}");
                throw;
            }
        }



        /// <summary>
        /// Guarda una nueva entidad en la base de datos.
        /// </summary>
        /// <param name="entity">La entidad que se va a guardar.</param>
        /// <returns>Una tarea que representa la operación asincrónica, conteniendo la entidad guardada.</returns>
        /// <summary>
        /// Saves a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to be saved.</param>
        /// <returns>A task representing the asynchronous operation, containing the saved entity.</returns>
        public override async Task<T> Save(T entity)
        {
            try
            {
                // Set default properties for the entity
                entity.CreatedAt = DateTime.UtcNow.AddHours(-5);
                entity.State = true;

                // Check if the entity has the 'Code' property (using reflection)
                var codeProperty = typeof(T).GetProperty("Code");
                if (codeProperty != null && codeProperty.CanWrite)
                {
                    // If the entity has the 'Code' property, generate a consecutive code using the helper service
                    string generatedCode = await _helperRepository.GenerateConsecutiveCode();
                    codeProperty.SetValue(entity, generatedCode); // Set the generated code
                }

                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza una entidad existente en la base de datos.
        /// </summary>
        /// <param name="entity">La entidad que se va a actualizar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public override async Task Update(T entityUpdated)
        {
            try
            {
                T entity = await GetById(entityUpdated.Id);
                entityUpdated.CreatedAt = entity.CreatedAt;

                _context.Entry(entityUpdated).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                _context.Entry(entityUpdated).State = EntityState.Detached;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar los datos: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Marca una entidad como eliminada estableciendo la marca de tiempo DeletedAt y deshabilitando su estado.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a eliminar lógicamente.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        /// <exception cref="Exception">Se lanza si no se encuentra la entidad.</exception>
        public override async Task Delete(int id)
        {
            bool validateRelationships = await _helperRepository.ValidateEntityRelationships(id);
            if (validateRelationships)
            {
                T entity = await GetById(id);

                entity.DeletedAt = DateTime.UtcNow.AddHours(-5);
                entity.State = false;
                await Update(entity);
            }
            else
            {
                throw new Exception("Se encontraron entidades relacionadas, no se puede eliminar la entidad");
            }
        }

        /// <summary>
        /// Restaura una entidad previamente eliminada, limpiando la fecha de eliminación y reactivando su estado.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a restaurar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        public override async Task Restore(int id)
        {
            T userId = await GetById(id);

            if (userId == null)
                throw new Exception("Entidad no encontrada");

            userId.DeletedAt = null;  // Se limpia la fecha de eliminación
            userId.State = true;      // Se vuelve a marcar como activa

            await Update(userId);
        }
    }
}

