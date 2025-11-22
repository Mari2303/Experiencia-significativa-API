using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleSegurity;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleSegurityRepository
{
    /// <summary>
    /// Implementación del repositorio para operaciones relacionadas con 
    /// Roles, Formularios y Permisos.
    /// </summary>
    public class RoleFormPermissionRepository
        : BaseModelRepository<RoleFormPermission, RoleFormPermissionDTO, RoleFormPermissionRequest>, IRoleFormPermissionRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<RoleFormPermission, RoleFormPermissionDTO> _helperRepository;

        public RoleFormPermissionRepository(
            ApplicationContext context,
            IMapper mapper,
            IConfiguration configuration,
            IHelper<RoleFormPermission, RoleFormPermissionDTO> helperRepository
        ) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }

        /// <summary>
        /// Obtiene (donde <c>DeletedAt</c> es nulo) una lista filtrada, ordenada y paginada 
        /// de registros de <see cref="RoleFormPermission"/> según los filtros especificados.
        /// </summary>
        /// <param name="filters">
        /// Instancia de <see cref="QueryFilterRequest"/> que contiene parámetros opcionales 
        /// para filtrado, ordenamiento, paginación y restricciones por clave foránea.
        /// </param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es un <see cref="IEnumerable{RoleFormPermissionRequest}"/> 
        /// con la lista de registros que cumplen los filtros y paginación aplicados.
        /// </returns>
        /// <exception cref="Exception">
        /// Lanza una excepción si ocurre un error durante la ejecución de la consulta o el mapeo de datos.
        /// </exception>
        public override async Task<IEnumerable<RoleFormPermissionRequest>> GetAll(QueryFilterRequest filters)
        {
            try
            {
                int pageNumber = filters.PageNumber.HasValue && filters.PageNumber.Value > 0
                    ? filters.PageNumber.Value
                    : _configuration.GetValue<int>("Pagination:DefaultPageNumber");

                int pageSize = filters.PageSize.HasValue && filters.PageSize.Value > 0
                    ? filters.PageSize.Value
                    : _configuration.GetValue<int>("Pagination:DefaultPageSize");

                filters.ColumnOrder ??= _configuration.GetValue<string>("Ordering:DefaultColumnOrder");
                filters.DirectionOrder ??= _configuration.GetValue<string>("Ordering:DefaultDirectionOrder");

                var sql = @"SELECT
                            roleFormPermissions.Id,
                            roleFormPermissions.RoleId,
                            roleFormPermissions.FormId,
                            roleFormPermissions.PermissionId,
                            r.Name AS Role,
                            f.Name AS Form,
                            p.Name AS Permission
                        FROM
                            RoleFormPermissions AS roleFormPermissions
                        INNER JOIN Roles AS r ON roleFormPermissions.RoleId = r.Id 
                        INNER JOIN Forms AS f ON roleFormPermissions.FormId = f.Id
                        INNER JOIN Permissions AS p ON roleFormPermissions.PermissionId = p.Id
                        WHERE roleFormPermissions.DeletedAt IS NULL ";

                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    sql += @"AND roleFormPermissions." + filters.NameForeignKey + @" = @foreignKey ";
                }

                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    // Filtro de búsqueda concatenando Role, Form y Permission
                    sql += @"AND (UPPER(CONCAT(r.Name, f.Name, p.Name)) 
                              LIKE UPPER(CONCAT('%', @filter, '%'))) ";
                }

                sql += @"ORDER BY roleFormPermissions." + filters.ColumnOrder + @" " + filters.DirectionOrder;

                IEnumerable<RoleFormPermissionRequest> items = await _context.QueryAsync<RoleFormPermissionRequest>(
                    sql,
                    new { filter = filters.Filter, foreignKey = filters.ForeignKey }
                );

                // Aplicar paginación
                if (filters.AplyPagination)
                {
                    int skip = (pageNumber - 1) * pageSize;
                    items = items.Skip(skip).Take(pageSize);
                }

                return items;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos: {ex.Message}");
                throw;
            }
        }
    }
}

