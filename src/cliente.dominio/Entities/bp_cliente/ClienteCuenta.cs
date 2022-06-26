namespace cliente.dominio.Entities.bp_cliente
{
    public class ClienteCuenta : AuditBaseClass
    {
        public int IdClienteCuenta { get; set; }
        public int IdCliente { get; set; }
        public int IdCuenta { get; set; }
        public string ClaveCliente { get; set; } = null!;

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Cuenta IdCuentaNavigation { get; set; } = null!;
    }
}
