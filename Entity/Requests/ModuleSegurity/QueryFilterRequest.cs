namespace Entity.Requests.ModuleSegurity
{
    /// <summary>
    /// Request utilizado para encapsular criterios de filtrado, ordenamiento y paginación en consultas.
    /// </summary>
    public class QueryFilterRequest
    {
        /// <summary>
        /// Número de elementos por página.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Número de página actual (basado en índice 1).
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Texto usado para filtrar resultados.
        /// </summary>
        public string? Filter { get; set; }

        /// <summary>
        /// Nombre de la columna sobre la cual se aplicará el filtro.
        /// </summary>
        public string? ColumnFilter { get; set; }

        /// <summary>
        /// Nombre de la columna utilizada para ordenar los resultados.
        /// </summary>
        public string? ColumnOrder { get; set; }

        /// <summary>
        /// Dirección del ordenamiento: "asc" (ascendente) o "desc" (descendente).
        /// </summary>
        public string? DirectionOrder { get; set; }

        /// <summary>
        /// Valor de clave foránea opcional para filtrar entidades relacionadas.
        /// </summary>
        public int? ForeignKey { get; set; }

        /// <summary>
        /// Nombre de la propiedad de clave foránea usada para filtrar.
        /// </summary>
        public string? NameForeignKey { get; set; }

        /// <summary>
        /// Indica si se debe aplicar paginación (true o false).
        /// </summary>
        public bool AplyPagination { get; set; }

        /// <summary>
        /// Rol del usuario que realiza la consulta (para restricciones de acceso).
        /// </summary>
        public string? Role { get; set; }

        /// <summary>
        /// Id del usuario que realiza la consulta (para restricciones de acceso).
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Si es true, solo trae entidades activas.
        /// </summary>
        public bool? OnlyState { get; set; }
    }
}
