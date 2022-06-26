using System.Security;

namespace cliente.dominio.Entities.bp_cliente
{
    public class Cliente : AuditBaseClass
    {
        public Cliente()
        {
            ClientesCuenta = new HashSet<ClienteCuenta>();
        }

        public int IdPersona { get; set; } 
        public int IdCliente { get; set; }
        public string Contrasena { get; set; } = null!;
        

        public virtual Persona IdPersonaNavigation { get; set; } = null!;
        public virtual ICollection<ClienteCuenta> ClientesCuenta { get; set; }
    }
}
