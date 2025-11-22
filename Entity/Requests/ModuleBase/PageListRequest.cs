using Entity.Requests.ModuleSegurity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Entity.Requests.ModuleBase
{
    /// <summary>
    /// Representa una lista paginada de elementos con metadatos para navegación 
    /// y listas opcionales filtradas.
    /// Hereda de <see cref="List{T}"/>.
    /// </summary>
    /// <typeparam name="T">El tipo de elementos en la lista paginada.</typeparam>
    public class PagedListRequest<T> : List<T>
    {
        /// <summary>
        /// Obtiene o establece el número de página actual.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Obtiene o establece el número total de páginas.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Obtiene o establece el tamaño de cada página (cantidad de elementos).
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Obtiene o establece el número total de elementos en todas las páginas.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Obtiene o establece datos adicionales relacionados, 
        /// como listas de selección o filtros.
        /// </summary>
        public object Lists { get; set; }

        /// <summary>
        /// Indica si existe una página anterior.
        /// </summary>
        public bool HasPreviousPage => CurrentPage > 1;

        /// <summary>
        /// Indica si existe una página siguiente.
        /// </summary>
        public bool HasNextPage => CurrentPage < TotalPages;

        /// <summary>
        /// Obtiene el número de la página siguiente si está disponible; de lo contrario, null.
        /// </summary>
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : null;

        /// <summary>
        /// Obtiene el número de la página anterior si está disponible; de lo contrario, null.
        /// </summary>
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : null;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PagedListRequest{T}"/>.
        /// </summary>
        /// <param name="items">Los elementos a incluir en la página actual.</param>
        /// <param name="count">El número total de elementos en la lista completa.</param>
        /// <param name="pageNumber">El número de página actual (basado en 1).</param>
        /// <param name="pageSize">El número de elementos por página.</param>
        /// <param name="lists">Listas relacionadas o metadatos opcionales.</param>
        public PagedListRequest(List<T> items, int count, int pageNumber = 1, int pageSize = 10, object lists = null)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Lists = lists;

            AddRange(items);
        }

        /// <summary>
        /// Crea una nueva <see cref="PagedListRequest{T}"/> a partir de una colección origen,
        /// aplicando la lógica de paginación.
        /// </summary>
        /// <param name="source">La colección completa de origen.</param>
        /// <param name="pageNumber">El número de página a devolver.</param>
        /// <param name="pageSize">El número de elementos por página.</param>
        /// <param name="lists">Datos relacionados opcionales para incluir.</param>
        /// <returns>Una lista paginada de elementos de la fuente.</returns>
        public static PagedListRequest<T> Create(IEnumerable<T> source, int pageNumber, int pageSize, object lists = null)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedListRequest<T>(items, count, pageNumber, pageSize, lists);
        }

        /// <summary>
        /// Aplica filtros dinámicos a la colección fuente utilizando la columna y cadena de filtro especificada.
        /// </summary>
        /// <param name="query">La colección fuente a filtrar.</param>
        /// <param name="queryFilterDto">Los criterios de filtrado.</param>
        /// <returns>Una colección filtrada de elementos.</returns>
        public static IQueryable<T> ApplyDynamicFilters(IQueryable<T> query, QueryFilterRequest queryFilterDto)
        {
            return query.Where(i => EF.Property<string>(i, queryFilterDto.ColumnFilter).Contains(queryFilterDto.Filter));
        }

        /// <summary>
        /// Aplica ordenamiento dinámico a la colección fuente utilizando la columna y dirección especificada.
        /// </summary>
        /// <param name="query">La colección fuente a ordenar.</param>
        /// <param name="queryFilterDto">Los criterios de ordenamiento.</param>
        /// <returns>Una colección ordenada (IOrderedQueryable).</returns>
        public static IOrderedQueryable<T> ApplyOrdering(IEnumerable<T> query, QueryFilterRequest queryFilterDto)
        {
            if (!string.IsNullOrEmpty(queryFilterDto.ColumnOrder))
            {
                var queryIQueryable = query.AsQueryable();
                query = OrderByProperty(queryIQueryable, queryFilterDto.ColumnOrder, queryFilterDto.DirectionOrder);
            }

            return query as IOrderedQueryable<T>;
        }

        /// <summary>
        /// Ordena dinámicamente la colección fuente según la propiedad y la dirección especificada.
        /// </summary>
        /// <param name="source">La fuente de datos IQueryable.</param>
        /// <param name="propertyName">El nombre de la propiedad por la que se ordenará.</param>
        /// <param name="direction">La dirección del orden ("asc" o "desc").</param>
        /// <returns>La colección ordenada.</returns>
        public static IOrderedQueryable<T> OrderByProperty<T>(IQueryable<T> source, string propertyName, string direction)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var resultExp = Expression.Call(
                typeof(Queryable),
                direction == "desc" ? "OrderByDescending" : "OrderBy",
                new[] { type, property.PropertyType },
                source.Expression,
                Expression.Quote(orderByExp)
            );

            return source.Provider.CreateQuery<T>(resultExp) as IOrderedQueryable<T>;
        }
    }
}

