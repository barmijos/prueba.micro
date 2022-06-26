using Ardalis.Specification;

namespace cliente.aplicacion.Operations.Cuenta.Querys
{
    internal class CuentaSpec : Specification<dominio.Entities.bp_cliente.Cuenta>, ISingleResultSpecification
    {
       
        public CuentaSpec(int idCuenta, string estado = "A")
        {
            Query.Where(h => h.IdCuenta == idCuenta && h.Estado == estado);
        }

        public CuentaSpec(string numeroCuenta, string estado = "A")
        {
            Query.Where(h => h.NumeroCuenta == numeroCuenta && h.Estado == estado);
        }
    }

    internal class ClienteCuentaSpec : Specification<dominio.Entities.bp_cliente.ClienteCuenta>, ISingleResultSpecification
    {

        public ClienteCuentaSpec(int idCuenta, int idCliente, string estado = "A")
        {
            Query.Where(h => h.IdCuenta == idCuenta && h.Estado == estado && h.IdCliente == idCliente);
        }
    }

    internal class ClienteCuentasSpec : Specification<dominio.Entities.bp_cliente.ClienteCuenta>
    {
        public ClienteCuentasSpec(int idCliente)
        {
            Query.Where(h => h.IdCliente == idCliente && h.Estado == "A");
        }
    }
}
