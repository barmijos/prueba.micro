using System;
using System.Collections.Generic;

namespace ClassLibrary1.Models
{
    public partial class BpPersona
    {
        public BpPersona()
        {
            BpClientes = new HashSet<BpCliente>();
        }

        public int IdPersona { get; set; }
        public string? NombrePersona { get; set; }
        public string? GeneroPersona { get; set; }
        public short? EdadPersona { get; set; }
        public string? IdentificacionPersona { get; set; }
        public string? DireccionPersona { get; set; }
        public string? TelefonoPersona { get; set; }

        public virtual ICollection<BpCliente> BpClientes { get; set; }
    }
}
