namespace cliente.dominio.Entities.EstadoCuenta
{
    public class ClienteFecha
    {
        public string Nombre { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<ReporteSaldoMovimiento> TotalesCuenta { get; set; } = new List<ReporteSaldoMovimiento>();

    }

    public class ReporteSaldoMovimiento
    {
        public string NumeroCuenta { get; set; } = null!;
        public string TipoCuenta { get; set; } = null!;
        public decimal Saldo { get; set; }
        public decimal SaldoDebito { get; set; }
        public decimal SaldoCredito { get; set; }
        public List<ReporteMovimiento>Movimientos { get; set; } = new List<ReporteMovimiento>();
    }

    public class ReporteMovimiento
    {
        public DateTime FechaTransaccion { get; set; }
        public string TipoTransaccion { get; set; } = null!;
        public decimal MontoMovimiento { get; set; }
    }
}
