namespace cliente.dominio.Entities.bp_cliente
{
    public class Movimiento 
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public decimal ValorMovimiento { get; set; }
        public decimal SaldoCuenta { get; set; }

        public virtual Cuenta IdCuentaNavigation { get; set; } = null!;
    }
}
