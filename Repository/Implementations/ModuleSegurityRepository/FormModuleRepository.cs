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
    /// Implementación del repositorio para manejar operaciones entre formularios y módulos.
    /// </summary>
    public class FormModuleRepository
        : BaseModelRepository<FormModule, FormModuleDTO, FormModuleRequest>, IFormModuleRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<FormModule, FormModuleDTO> _helperRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormModuleRepository"/>.
        /// </summary>
        /// <param name="context">El contexto de base de datos de la aplicación.</param>
        /// <param name="mapper">El servicio de AutoMapper para mapear entidades y DTOs.</param>
        /// <param name="configuration">El servicio de configuración de la aplicación.</param>
        /// <param name="helperRepository">Helper genérico para reutilizar operaciones comunes.</param>
        public FormModuleRepository(
            ApplicationContext context,
            IMapper mapper,
            IConfiguration configuration,
            IHelper<FormModule, FormModuleDTO> helperRepository
        ) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }

        /// <summary>
        /// Obtiene (donde <c>DeletedAt</c> es nulo) una lista filtrada, ordenada y paginada 
        /// de <see cref="FormModuleRequest"/> según los filtros proporcionados.
        /// </summary>
        /// <param name="filters">
        /// Objeto <see cref="QueryFilterRequest"/> que contiene los parámetros opcionales para:
        /// - Filtrado
        /// - Ordenamiento
        /// - Paginación
        /// - Restricciones por clave foránea
        /// </param>
        /// <returns>
        /// Una tarea asincrónica que devuelve un <see cref="IEnumerable{FormModuleRequest}"/> 
        /// con los registros que cumplen las condiciones de búsqueda.
        /// </returns>
        /// <exception cref="Exception">
        /// Se lanza si ocurre algún error durante la ejecución de la consulta o el mapeo de datos.
        /// </exception>
        public override async Task<IEnumerable<FormModuleRequest>> GetAll(QueryFilterRequest filters)
        {
            try
            {
                // 1. Definir paginación por defecto si no viene en el request
                int pageNumber = filters.PageNumber.HasValue && filters.PageNumber.Value > 0
                    ? filters.PageNumber.Value
                    : _configuration.GetValue<int>("Pagination:DefaultPageNumber");

                int pageSize = filters.PageSize.HasValue && filters.PageSize.Value > 0
                    ? filters.PageSize.Value
                    : _configuration.GetValue<int>("Pagination:DefaultPageSize");

                // 2. Definir ordenamiento por defecto si no se especifica
                filters.ColumnOrder ??= _configuration.GetValue<string>("Ordering:DefaultColumnOrder");
                filters.DirectionOrder ??= _configuration.GetValue<string>("Ordering:DefaultDirectionOrder");

                // 3. Construcción dinámica del SQL
                var sql = @"
                        SELECT
                            formModule.Id,
                            formModule.FormId,
                            formModule.ModuleId,
                            f.Name AS Form,
                            m.Name AS Module
                        FROM
                            FormModules AS formModule
                        INNER JOIN Forms AS f ON formModule.FormId = f.Id 
                        INNER JOIN Modules AS m ON formModule.ModuleId = m.Id 
                        WHERE formModule.DeletedAt IS NULL ";

                // Filtrar por clave foránea si aplica
                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    sql += @"AND formModule." + filters.NameForeignKey + @" = @foreignKey ";
                }

                // Filtro de texto (ejemplo: búsqueda por nombre de form o módulo)
                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    sql += @"AND (UPPER(CONCAT(f.Name, m.Name)) LIKE UPPER(CONCAT('%', @filter, '%'))) ";
                }

                // Ordenamiento
                sql += @"ORDER BY formModule." + filters.ColumnOrder + " " + filters.DirectionOrder;

                // 4. Ejecutar la consulta
                IEnumerable<FormModuleRequest> items = await _context.QueryAsync<FormModuleRequest>(
                    sql,
                    new { filter = filters.Filter, foreignKey = filters.ForeignKey }
                );

                // 5. Aplicar paginación si corresponde
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

