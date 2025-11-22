using AutoMapper;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using System.ComponentModel;
using Entity.Dtos.ModuleBase;
using Entity.Models.ModuleBase;
using Entity.Requests.ModuleSegurity;

namespace Utilities.Helper
{
    /// <summary>
    /// Implementación concreta de <see cref="AHelper{T, D}"/> que utiliza reflexión y árboles de expresión
    /// para validar dinámicamente si una entidad de tipo <typeparamref name="T"/> está referenciada por otras entidades activas en la base de datos.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad, que debe heredar de <see cref="BaseModel"/>.</typeparam>
    /// <typeparam name="D">El tipo de DTO, que debe heredar de <see cref="BaseDTO"/>.</typeparam>
    public class Helper<T, D> : AHelper<T, D>
        where T : BaseModel
        where D : BaseDTO
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Helper{T, D}"/> con el contexto de base de datos y el mapper especificados.
        /// </summary>
        /// <param name="context">El contexto de Entity Framework utilizado para consultar las relaciones de las entidades.</param>
        /// <param name="mapper">El objeto mapper utilizado para transformar modelos a DTO.</param>
        public Helper(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Valida si la entidad de tipo <typeparamref name="T"/> con el ID dado está referenciada por registros activos
        /// en otras entidades dentro del DbContext actual.
        /// </summary>
        /// <param name="id">El identificador de la entidad a validar.</param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado es <c>true</c> si no existen dependencias de clave foránea activas; 
        /// de lo contrario, <c>false</c>.
        /// </returns>
        public override async Task<bool> ValidateEntityRelationships(int id)
        {
            var targetEntityName = typeof(T).Name;

            foreach (var entityType in _context.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                var properties = clrType.GetProperties();

                var navigationExists = properties.Any(p =>
                    p.PropertyType == typeof(T) ||
                    p.PropertyType.IsClass && p.PropertyType.Name == targetEntityName);

                if (!navigationExists)
                    continue;

                var fkProperty = properties.FirstOrDefault(p =>
                    p.Name == targetEntityName + "Id" && p.PropertyType == typeof(int));

                var stateProperty = properties.FirstOrDefault(p =>
                    p.Name == "State" && p.PropertyType == typeof(bool));

                if (fkProperty == null || stateProperty == null)
                    continue;

                var setMethod = typeof(DbContext).GetMethod(nameof(DbContext.Set), Type.EmptyTypes);
                var genericSetMethod = setMethod!.MakeGenericMethod(clrType);
                var dbSet = genericSetMethod.Invoke(_context, null);
                var queryable = dbSet as IQueryable;

                if (queryable == null)
                    continue;

                var parameter = Expression.Parameter(clrType, "x");
                var propertyFk = Expression.Property(parameter, fkProperty);
                var propertyState = Expression.Property(parameter, stateProperty);

                var constantId = Expression.Constant(id);
                var constantTrue = Expression.Constant(true);

                var fkEquals = Expression.Equal(propertyFk, constantId);
                var stateEquals = Expression.Equal(propertyState, constantTrue);

                var combinedCondition = Expression.AndAlso(fkEquals, stateEquals);
                var lambda = Expression.Lambda(combinedCondition, parameter);

                var whereMethod = typeof(Queryable)
                    .GetMethods()
                    .First(m => m.Name == "Where" && m.GetParameters().Length == 2)
                    .MakeGenericMethod(clrType);

                var filteredQuery = whereMethod.Invoke(null, new object[] { queryable, lambda });

                var toListAsyncMethod = typeof(EntityFrameworkQueryableExtensions)
                    .GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .First(m => m.Name == "ToListAsync" && m.GetParameters().Length == 2)
                    .MakeGenericMethod(clrType);

                var task = (Task)toListAsyncMethod.Invoke(null, new object[] { filteredQuery, CancellationToken.None })!;
                await task.ConfigureAwait(false);

                var resultProperty = task.GetType().GetProperty("Result");
                var list = resultProperty!.GetValue(task) as IEnumerable<object>;

                if (list!.Any())
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Genera un código consecutivo delegando la lógica a la capa de repositorio.
        /// </summary>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado contiene el código consecutivo generado como cadena de 4 dígitos (por ejemplo, "0001", "0002").
        /// </returns>
        public override async Task<string> GenerateConsecutiveCode()
        {
            var lastCodeStr = await _context.Set<T>()
                .AsNoTracking()
                .Where(e => EF.Property<string>(e, "Code") != null)
                .Select(e => EF.Property<string>(e, "Code"))
                .ToListAsync();

            var lastCodeInt = lastCodeStr.Select(code =>
            {
                bool isParsed = int.TryParse(code, out int val);
                return (isParsed, val);
            }).Where(x => x.isParsed).Select(x => x.val).DefaultIfEmpty(0).Max();

            int newCode = lastCodeInt + 1;
            return newCode.ToString("D4");
        }

        /// <summary>
        /// Obtiene una lista de pares clave-valor que representan los valores de un enum especificado.
        /// Utiliza reflexión para localizar el enum por nombre en el espacio de nombres <c>Entity.Models</c> y extrae su valor numérico y el <see cref="DescriptionAttribute"/> asociado.
        /// </summary>
        /// <param name="enumName">El nombre del enum a recuperar, por ejemplo "DocumentType" o "Gender".</param>
        /// <returns>
        /// Una tarea que representa la operación asíncrona. El resultado es una lista de <see cref="DataSelectRequest"/> que contiene el valor del enum (Id) y su descripción (DisplayText).
        /// </returns>
        /// <exception cref="ArgumentException">Se lanza si el tipo de enum no se encuentra o no es un enumerado válido.</exception>
        public override async Task<List<DataSelectRequest>> GetEnum(string enumName)
        {
            var enumType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.IsEnum && t.Name.Equals(enumName, StringComparison.OrdinalIgnoreCase));

            if (enumType == null || !enumType.IsEnum)
                throw new ArgumentException($"Enum '{enumName}' no encontrado o no es un enum válido.");

            var result = new List<DataSelectRequest>();

            foreach (var value in Enum.GetValues(enumType))
            {
                var memberInfo = enumType.GetMember(value.ToString()!);
                var description = memberInfo[0]
                    .GetCustomAttribute<DescriptionAttribute>()?.Description ?? value.ToString();

                result.Add(new DataSelectRequest
                {
                    Id = Convert.ToInt64(value), // soporte para int y long
                    DisplayText = description!
                });
            }

            return result;
        }

        /// <summary>
        /// Valida los datos importados del DTO proporcionado.
        /// </summary>
        /// <param name="request">El DTO que contiene los datos a validar.</param>
        /// <returns>Una tarea que representa la operación asíncrona. El resultado indica si los datos son válidos (<c>true</c>) o no (<c>false</c>).</returns>
        public override async Task<bool> ValidateDataImport(D request)
        {
            if (request == null) return false;

            // Propiedades heredadas que se permiten nulas o vacías
            var excludedProps = typeof(BaseDTO)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => p.Name)
                .ToHashSet();

            // Propiedades de la clase derivada
            var propsToValidate = typeof(D)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => !excludedProps.Contains(p.Name));

            foreach (var prop in propsToValidate)
            {
                var value = prop.GetValue(request);

                if (value == null)
                    return false;

                if (prop.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(value.ToString()))
                    return false;
            }

            return true;
        }
    }
}
