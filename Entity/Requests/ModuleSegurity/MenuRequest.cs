namespace Entity.Requests.ModuleSegurity
{
    /// <summary>
    /// Petición para mostrar un menú
    /// </summary>
    public class MenuRequest
    {
        /// <summary>
        /// Referencia al ID del formulario
        /// </summary>
        public int FormId { get; set; }

        /// <summary>
        /// Nombre del formulario
        /// </summary>
        public string Form { get; set; } = string.Empty;

        /// <summary>
        /// Ruta o URL para acceder al formulario
        /// </summary>
        public string Path { get; set; } = string.Empty;

        /// <summary>
        /// Identificador del ícono para mostrar en la interfaz
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// Orden de visualización del formulario en la interfaz
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Referencia al ID del módulo
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// Nombre del módulo
        /// </summary>
        public string Module { get; set; } = string.Empty;
    }
}
