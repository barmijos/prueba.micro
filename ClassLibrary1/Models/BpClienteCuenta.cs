using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class BpClienteCuenta
    {
        public int IdClienteCuenta { get; set; }
        public int IdCliente { get; set; }
        public int IdCuenta { get; set; }
        public string ClaveCliente { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual BpCliente IdClienteNavigation { get; set; } = null!;
        public virtual BpCuenta IdCuentaNavigation { get; set; } = null!;
    }
}
