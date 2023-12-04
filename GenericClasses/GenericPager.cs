namespace RedBrowBackend.GenericClasses
{
    public class GenericPager<T> where T : class
    {
        /// <summary>
        /// Página devuelta por la consulta actual.
        /// </summary>
        public int ActualPage { get; set; }
        /// <summary>
        /// Número de registros de la página devuelta.
        /// </summary>
        public int RecordsPerPage { get; set; }
        /// <summary>
        /// Total de registros de consulta.
        /// </summary>
        public int TotalRecords { get; set; }
        /// <summary>
        /// Total de páginas de la consulta.
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// Columna por la que esta ordenada la consulta actual.
        /// </summary>
        public string CurrentOrder { get; set; }
        /// <summary>
        /// Tipo de ordenación de la consulta actual: ASC o DESC.
        /// </summary>
        public string CurrentOrderType { get; set; }
        /// <summary>
        /// Resultado devuelto por la consulta a la tabla Users
        /// en función de todos los parámetros anteriores.
        /// </summary>
        public IEnumerable<T> Result { get; set; }
    }
}
