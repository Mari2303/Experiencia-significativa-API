using AutoMapper;
using Entity.Context;
using Entity.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Utilities.Helper;
using Repository.Implementations.ModuleBaseRepository;
using Repository.Interfaces.IModuleSegurityRepository;
using Entity.Dtos.ModuleSegurity;
using Entity.Requests.ModuleSegurity;

namespace Repository.Implementations.ModuleSegurityRepository
{
    /// <summary>
    /// Implementación del repositorio para operaciones relacionadas con Usuarios.
    /// </summary>
    public class UserRepository : BaseModelRepository<User, UserDTO, UserRequest>, IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IHelper<User, UserDTO> _helperRepository;

        public UserRepository(
            ApplicationContext context,
            IMapper mapper,
            IConfiguration configuration,
            IHelper<User, UserDTO> helperRepository
        ) : base(context, mapper, configuration, helperRepository)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _helperRepository = helperRepository;
        }

        /// <summary>
        /// Obtiene (donde <c>DeletedAt</c> es nulo) una lista filtrada, ordenada y paginada de Usuarios
        /// según los filtros especificados.
        /// </summary>
        /// <param name="filters">
        /// Instancia de <see cref="QueryFilterRequest"/> que contiene parámetros opcionales 
        /// para filtrado, ordenamiento, paginación y restricciones por clave foránea.
        /// </param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es un <see cref="IEnumerable{UserRequest}"/> 
        /// con la lista de usuarios que cumplen los filtros y paginación aplicados.
        /// </returns>
        /// <exception cref="Exception">
        /// Lanza una excepción si ocurre un error durante la ejecución de la consulta o el mapeo de datos.
        /// </exception>
        public override async Task<IEnumerable<UserRequest>> GetAll(QueryFilterRequest filters)
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
                            usu.Id,
                            usu.State,
                            usu.CreatedAt,
                            usu.DeletedAt,
                            usu.Code,
                            usu.Username,
                            usu.PersonId,
                            usu.Password,
                            CONCAT(person.FirstName,' ', person.FirstLastName) AS Person
                        FROM
                            Users AS usu
                        INNER JOIN Persons AS person ON usu.PersonId = person.Id
                        WHERE usu.DeletedAt IS NULL ";

                if (filters.ForeignKey != null && !string.IsNullOrEmpty(filters.NameForeignKey))
                {
                    sql += @"AND usu." + filters.NameForeignKey + @" = @foreignKey ";
                }

                if (!string.IsNullOrEmpty(filters.Filter))
                {
                    sql += @"AND (UPPER(usu.Username) LIKE UPPER(CONCAT('%', @filter, '%'))) ";
                }

                sql += @"ORDER BY usu." + filters.ColumnOrder + @" " + filters.DirectionOrder;

                IEnumerable<UserRequest> items = await _context.QueryAsync<UserRequest>(
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
                Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="name">Nombre de usuario.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es una instancia de <see cref="UserRequest"/> o null si no existe.
        /// </returns>
        public async Task<UserRequest> GetByName(string name)
        {
            try
            {
                var sql = @"SELECT
                            usu.Id,
                            usu.State,
                            usu.CreatedAt,
                            usu.DeletedAt,
                            usu.Code,
                            usu.Username,
                            usu.PersonId,
                            usu.Password,
                            CONCAT(person.FirstName,' ', person.FirstLastName) AS Person
                        FROM
                            Users AS usu
                        INNER JOIN Persons AS person ON usu.PersonId = person.Id
                        WHERE usu.Username = @username AND usu.DeletedAt IS NULL";

                return await _context.QueryFirstOrDefaultAsync<UserRequest>(sql, new { username = name });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuario por nombre: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene el menú de accesos del usuario según sus roles y permisos.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns>
        /// Una tarea asincrónica cuyo resultado es una lista de <see cref="MenuRequest"/> 
        /// con los formularios y módulos accesibles por el usuario.
        /// </returns>
        public async Task<List<MenuRequest>> GetMenuAsync(int userId)
        {
            try
            {
                return await (
                    from u in _context.Users
                    join ur in _context.UserRoles on u.Id equals ur.UserId
                    join rfp in _context.RoleFormPermissions on ur.RoleId equals rfp.RoleId
                    join f in _context.Forms on rfp.FormId equals f.Id
                    join fm in _context.FormModules on f.Id equals fm.FormId
                    join m in _context.Modules on fm.ModuleId equals m.Id
                    where u.Id == userId
                    orderby f.Order
                    select new MenuRequest
                    {
                        FormId = f.Id,
                        Form = f.Name,
                        Path = f.Path,
                        Icon = f.Icon,
                        Order = f.Order,
                        ModuleId = m.Id,
                        Module = m.Name
                    }
                ).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener menú del usuario: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Agrega un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="entity">Entidad usuario a agregar.</param>
        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Obtiene la lista de roles asociados a un usuario.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns>Lista de nombres de roles asociados al usuario.</returns>
        public async Task<List<string>> GetRolesByUserId(int userId)
        {
            return await _context.Users
               .Where(u => u.Id == userId)
               .Include(u => u.UserRoles)
                   .ThenInclude(ur => ur.Role)
               .SelectMany(u => u.UserRoles.Select(ur => ur.Role.Name))
               .ToListAsync();
        }

        /// <summary>
        /// Obtiene un usuario por el correo electrónico asociado a la persona.
        /// </summary>
        /// <param name="email">Correo electrónico de la persona.</param>
        /// <returns>Instancia de <see cref="User"/> o null si no existe.</returns>
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.Person)
                .FirstOrDefaultAsync(u => u.Person != null && u.Person.Email == email);
        }


        /// <summary>
        /// Actualiza la información de un usuario.
        /// </summary>
        /// <param name="user">Entidad usuario a actualizar.</param>
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }


        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .AsNoTracking()               // 👈 Esto evita el tracking
                .Include(u => u.Person)
                .FirstOrDefaultAsync(u => u.Id == id);
        }



        public async Task UpdateTwoFactorAsync(int userId, string twoFactorCode, DateTime expiration)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
                throw new Exception("Usuario no encontrado");

            user.RecoveryCode = twoFactorCode;
            user.RecoveryCodeExpiration = expiration;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateTwoAsync(int userId, string code, DateTime expiration)
        {
            var user = await _context.Users.FindAsync(userId);
            user.RecoveryCode = code;
            user.RecoveryCodeExpiration = expiration;
            await _context.SaveChangesAsync();
        }



        public async Task ClearTwoFactorCodeAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            user.RecoveryCode = null;
            user.RecoveryCodeExpiration = null;
            await _context.SaveChangesAsync();
        }





    }
}



