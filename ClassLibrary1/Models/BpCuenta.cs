using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class BpCuenta
    {
        public BpCuenta()
        {
            BpClienteCuenta = new HashSet<BpClienteCuenta>();
            BpMovimientos = new HashSet<BpMovimiento>();
        }

        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        public string TipoCuenta { get; set; } = null!;
        public decimal SaldoInicial { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<BpClienteCuenta> BpClienteCuenta { get; set; }
        public virtual ICollection<BpMovimiento> BpMovimientos { get; set; }
    }
}
