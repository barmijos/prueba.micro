using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class BpCliente
    {
        public BpCliente()
        {
            BpClienteCuenta = new HashSet<BpClienteCuenta>();
        }

        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
        public string ClaveCliente { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual BpPersona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<BpClienteCuenta> BpClienteCuenta { get; set; }
    }
}
