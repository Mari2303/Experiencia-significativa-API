using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleBase;
using Entity.Requests.ModuleSegurity;
using Repository.Interfaces.IModuleBaseRepository;

namespace Service.Implementations.ModuleBaseService
{
    /// <summary>
    /// Concrete implementation of the generic service layer for handling standard CRUD operations.
    /// This class provides the actual behavior for entity management and delegates persistence
    /// operations to the repository layer.
    /// </summary>
    /// <typeparam name="T">The entity type, inheriting from <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">The data transfer object (DTO) type, inheriting from <see cref="BaseDTO"/>.</typeparam>
    /// <typeparam name="R">The request type, inheriting from <see cref="BaseRequest"/>.</typeparam>
    public class BaseModelService<T, D, R> : ABaseModelService<T, D, R>
        where T : BaseModel
        where D : BaseDTO
        where R : BaseRequest
    {
        private readonly IBaseModelRepository<T, D, R> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseModelService{T, D, R}"/> class.
        /// </summary>
        /// <param name="repository">The repository instance used for data persistence.</param>
        public BaseModelService(IBaseModelRepository<T, D, R> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Marks an entity as deleted by delegating the operation to the repository layer.
        /// Usually this performs a logical delete (soft delete) rather than removing the record permanently.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to logically delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        /// <summary>
        /// Retrieves all entities from the repository, applying optional filtering.
        /// </summary>
        /// <param name="filters">An object containing query filter parameters (e.g. pagination, search, etc.).</param>
        /// <returns>A task representing the asynchronous operation, containing a list of request DTOs.</returns>
        public override async Task<IEnumerable<R>> GetAll(QueryFilterRequest filters)
        {
            return await _repository.GetAll(filters);
        }

        /// <summary>
        /// Retrieves a single entity by its unique identifier.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, containing the entity if found.</returns>
        public override async Task<T> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        /// <summary>
        /// Saves a new entity to the repository.
        /// The repository layer usually sets default values like CreatedAt and State = true.
        /// </summary>
        /// <param name="entity">The entity instance to be saved.</param>
        /// <returns>A task representing the asynchronous operation, containing the saved entity.</returns>
        public override async Task<T> Save(T entity)
        {
            return await _repository.Save(entity);
        }

        /// <summary>
        /// Updates an existing entity in the repository.
        /// The repository usually sets UpdatedAt before persisting the changes.
        /// </summary>
        /// <param name="entity">The entity instance to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public override async Task Update(T entity)
        {
            await _repository.Update(entity);
        }

        /// <summary>
        /// Restores an entity that was previously marked as deleted (soft delete).
        /// </summary>
        /// <param name="id">The unique identifier of the entity to restore.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="Exception">Thrown if the entity does not exist or is already active.</exception>
        public override async Task Restore(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
                throw new Exception("Entity not found");

            if (entity.State)
                throw new Exception("Entity is already active");

            await _repository.Restore(id);
        }
    }
}

