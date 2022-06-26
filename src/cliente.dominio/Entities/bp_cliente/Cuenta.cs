namespace cliente.dominio.Entities.bp_cliente
{
    public class Cuenta : AuditBaseClass
    {
        public Cuenta()
        {
            ClientesCuenta = new HashSet<ClienteCuenta>();
            Movimientos = new HashSet<Movimiento>();
        }

        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        public string TipoCuenta { get; set; } = null!;
        public decimal SaldoInicial { get; set; }

        public virtual ICollection<ClienteCuenta> ClientesCuenta { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
