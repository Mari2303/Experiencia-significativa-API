using AutoMapper;
using Entity.Context;
using Entity.Dtos.ModuleSegurity;
using Entity.Models;
using Entity.Models.ModuleSegurity;
using Entity.Requests.ModuleSegurity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Utilities.Helper;

namespace Repository.Implementations.ModuleSegurityRepository
{
    /// <summary>
    /// Implementación del repositorio para operaciones relacionadas con la entidad Persona.
    /// </summary>
    public class PersonRepository : BaseModelRepository<Person, PersonDTO, PersonRequest>, IPersonRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<Person, PersonDTO> _helperRepository;

        public PersonRepository(
            ApplicationContext context,
            IMapper mapper,
            IConfiguration configuration,
            IHelper<Person, PersonDTO> helperRepository
        ) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }

        /// <summary>
        /// Obtiene (donde <c>State</c> es verdadero) una lista filtrada, ordenada y paginada de DTOs 
        /// según los filtros de consulta especificados.
        /// </summary>
        /// <param name="filters">
        /// Una instancia de <see cref="QueryFilterRequest"/> que contiene parámetros opcionales 
        /// para filtrado, ordenamiento, paginación y restricciones por clave foránea.
        /// </param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es un <see cref="IEnumerable{PersonRequest}"/> 
        /// que representa la lista de DTOs mapeados que cumplen con los filtros y paginación aplicados.
        /// </returns>
        /// <exception cref="Exception">
        /// Lanza una excepción si ocurre un error durante la ejecución de la consulta o el mapeo de datos.
        /// </exception>
        public override async Task<IEnumerable<PersonRequest>> GetAll(QueryFilterRequest filters)
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
                            person.Id,
                            CASE person.DocumentType
                                WHEN 1 THEN 'Cédula de ciudadanía'
                                WHEN 2 THEN 'Tarjeta de identidad'
                                WHEN 3 THEN 'Cédula de extranjería'
                                ELSE 'Desconocido'
                            END AS DocumentType,
                            person.IdentificationNumber,
                            person.FirstName,
                            person.MiddleName,
                            person.FirstLastName,
                            person.SecondLastName,
                            CONCAT(person.FirstName, ' ', person.MiddleName, ' ', person.FirstLastName, ' ', person.SecondLastName) AS FullName,
                            person.Email,
                            person.EmailInstitutional,
                            person.CodeDane,
                            person.Phone,
                            person.State,
                            person.CreatedAt,
                            person.DeletedAt
                        FROM
                            Persons AS person
                        WHERE person.DeletedAt IS NULL ";

                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    sql += @"AND person." + filters.NameForeignKey + @" = @foreignKey ";
                }

                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    sql += @"AND (UPPER(CONCAT(person.FirstName, person.MiddleName, person.FirstLastName, person.SecondLastName)) 
                              LIKE UPPER(CONCAT('%', @filter, '%'))) ";
                }

                sql += @"ORDER BY person." + filters.ColumnOrder + @" " + filters.DirectionOrder;

                IEnumerable<PersonRequest> items = await _context.QueryAsync<PersonRequest>(
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
                Console.WriteLine($"Error al obtener los datos: {ex.Message}");
                throw;
            }
        }


        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Person) // Para poder acceder al correo
                .FirstOrDefaultAsync(u => u.Id == id);
        }


    }
}
