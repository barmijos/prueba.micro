using cliente.aplicacion.Wrappers.Parameters;

namespace cliente.aplicacion.Operations.Movimiento.Querys
{
    public class GenerarEstadosCuentaParameters : RequestParameters
    {
        public int IdCliente { get; set; } 
        public DateTime? FechaInicio { get; set; } 
        public DateTime? FechaFin { get; set; } 
    }
}
