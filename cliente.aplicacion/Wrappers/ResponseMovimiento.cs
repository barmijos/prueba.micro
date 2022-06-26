using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cliente.aplicacion.Wrappers
{
    public  class ResponseMovimiento<T> : ResponseCliente<T>
    { 
        /// <summary>
        /// Que pagina quiero
        /// </summary>
        public int NumeroPagina { get; set; }
        /// <summary>
        /// Cuantos registros por pagina
        /// </summary>
        public int NumeroRegistros { get; set; }

        public ResponseMovimiento(T data, int numeroPagina, int numeroRegistros)
        {
            NumeroPagina = numeroPagina;
            NumeroRegistros = numeroRegistros;
            this.Data = data;
            this.Success = true;
        }
    }
}
