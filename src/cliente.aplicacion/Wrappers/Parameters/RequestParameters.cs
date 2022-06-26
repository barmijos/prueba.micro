namespace cliente.aplicacion.Wrappers.Parameters
{
    public class RequestParameters
    {
        /// <summary>
        /// Que pagina quiero
        /// </summary>
        public int NumeroPagina { get; set; } = 1;
        /// <summary>
        /// Cuantos registros por pagina
        /// </summary>
        public int NumeroRegistros { get; set; } = 10;

        public RequestParameters()
        {

        }

        public RequestParameters(int numeroPagina, int numeroRegistros)
        {
            NumeroPagina = numeroPagina < 1 ? 1 : numeroPagina;
            NumeroRegistros = numeroRegistros > 50  ? 10 : numeroPagina;
        }
    }
}
