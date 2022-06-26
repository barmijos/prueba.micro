using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class BpMovimiento
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public decimal ValorMovimiento { get; set; }
        public decimal SaldoCuenta { get; set; }

        public virtual BpCuenta IdCuentaNavigation { get; set; } = null!;
    }
}
