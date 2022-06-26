namespace cliente.dominio.Entities.bp_cliente
{
    public class Persona 
    {
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public char Genero { get; set; }
        public short Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
