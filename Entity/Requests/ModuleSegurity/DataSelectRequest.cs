namespace Entity.Requests.ModuleSegurity
{
    /// <summary>
    /// Representa una petición de datos para selección.
    /// Esta clase se utiliza para encapsular la información de los ítems que se mostrarán en una lista de selección o un menú desplegable.
    /// </summary>
    public class DataSelectRequest
    {
        /// <summary>
        /// Obtiene o establece el identificador único del ítem de selección.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Obtiene o establece el texto que se mostrará para el ítem de selección.
        /// Este es el texto visible que aparecerá en una interfaz de selección, como un menú desplegable o una lista.
        /// </summary>
        public string DisplayText { get; set; } = null!;
    }
}

