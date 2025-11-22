using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces;
using Utilities.Helper;

namespace Repository.Implementations.ModuleSegurityRepository
{
    /// <summary>
    /// Implementación del repositorio para operaciones de asignación de usuarios a roles.
    /// </summary>
    public class UserRoleRepository : BaseModelRepository<UserRole, UserRoleDTO, UserRoleRequest>, IUserRoleRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<UserRole, UserRoleDTO> _helperRepository;

        /// <summary>
        /// Constructor del repositorio de UserRole.
        /// </summary>
        /// <param name="context">Contexto de la base de datos.</param>
        /// <param name="mapper">Instancia de AutoMapper para mapeos.</param>
        /// <param name="configuration">Configuración de la aplicación (paginación, ordenamiento, etc.).</param>
        /// <param name="helperRepository">Helper genérico para manejo de entidades y DTOs.</param>
        public UserRoleRepository(
            ApplicationContext context,
            IMapper mapper,
            IConfiguration configuration,
            IHelper<UserRole, UserRoleDTO> helperRepository
        ) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }

        /// <summary>
        /// Obtiene una lista filtrada, ordenada y paginada de las asignaciones de usuarios a roles.
        /// </summary>
        /// <param name="filters">
        /// Instancia de <see cref="QueryFilterRequest"/> que contiene parámetros opcionales
        /// para filtrado, ordenamiento, paginación y restricciones por llave foránea.
        /// </param>
        /// <returns>
        /// Una tarea que representa la operación asincrónica. El resultado es un <see cref="IEnumerable{UserRoleRequest}"/>
        /// con la lista de asignaciones usuario-rol que cumplen con los criterios aplicados.
        /// </returns>
        /// <exception cref="Exception">Lanza cualquier excepción encontrada durante la consulta o el mapeo.</exception>
        public override async Task<IEnumerable<UserRoleRequest>> GetAll(QueryFilterRequest filters)
        {
            try
            {
                int pageNumber = filters.PageNumber.HasValue && filters.PageNumber.Value > 0 ? filters.PageNumber.Value : _configuration.GetValue<int>("Pagination:DefaultPageNumber");
                int pageSize = filters.PageSize.HasValue && filters.PageSize.Value > 0 ? filters.PageSize.Value : _configuration.GetValue<int>("Pagination:DefaultPageSize");

                filters.ColumnOrder ??= _configuration.GetValue<string>("Ordering:DefaultColumnOrder");
                filters.DirectionOrder ??= _configuration.GetValue<string>("Ordering:DefaultDirectionOrder");

                var query = from ur in _context.UserRoles
                            join u in _context.Users on ur.UserId equals u.Id
                            join r in _context.Roles on ur.RoleId equals r.Id
                            where ur.DeletedAt == null
                            select new UserRoleRequest
                            {
                                Id = ur.Id,
                                UserId = ur.UserId,
                                RoleId = ur.RoleId,
                                User = u.Username,
                                Role = r.Name
                            };

                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    if (filters.NameForeignKey == "UserId")
                        query = query.Where(x => x.UserId == (int)filters.ForeignKey);
                    else if (filters.NameForeignKey == "RoleId")
                        query = query.Where(x => x.RoleId == (int)filters.ForeignKey);
                }

                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    var filterUpper = filters.Filter.ToUpper();
                    query = query.Where(x => (x.User.ToUpper() + x.Role.ToUpper()).Contains(filterUpper));
                }

                // Aplica orden
                if (filters.ColumnOrder == "User")
                {
                    query = filters.DirectionOrder == "ASC"
                        ? query.OrderBy(x => x.User)
                        : query.OrderByDescending(x => x.User);
                }
                else if (filters.ColumnOrder == "Role")
                {
                    query = filters.DirectionOrder == "ASC"
                        ? query.OrderBy(x => x.Role)
                        : query.OrderByDescending(x => x.Role);
                }
                else
                {
                    query = filters.DirectionOrder == "ASC"
                        ? query.OrderBy(x => x.Id)
                        : query.OrderByDescending(x => x.Id);
                }

                // Aplica paginación
                if (filters.AplyPagination)
                {
                    query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving data: {ex.Message}");
                throw;
            }
        }
    }
}

