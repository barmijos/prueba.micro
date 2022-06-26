using Ardalis.Specification;

namespace cliente.aplicacion.Operations.Movimiento.Querys
{
    internal class MovimientoSpec : Specification<dominio.Entities.bp_cliente.Movimiento>, ISingleResultSpecification
    {
        public MovimientoSpec(int idMovimiento, int idCuenta)
        {
            Query.Where(h => h.IdMovimiento == idMovimiento && h.IdCuenta == idCuenta);
        }

        public MovimientoSpec(int idCuenta, DateTime fechaProceso)
        {
            Query.Where(h => h.FechaMovimiento == fechaProceso && h.IdCuenta == idCuenta);
        }

        public MovimientoSpec(int idCuenta)
        {
            Query .Where(h => h.IdCuenta == idCuenta);
        }
    }

    internal class MovimientosCuenta : Specification<dominio.Entities.bp_cliente.Movimiento>
    {
        public MovimientosCuenta(int idCuenta, DateTime fechaInicio, DateTime fechaFin)
        {
            Query.Where(x=> x.IdCuenta== idCuenta && x.FechaMovimiento >=  fechaInicio && x.FechaMovimiento <= fechaFin);
        }
    }
}
