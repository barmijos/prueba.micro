using Ardalis.Specification;

namespace cliente.aplicacion.Operations.Cliente.Querys
{
    internal class ClienteSpec : Specification<dominio.Entities.bp_cliente.Cliente>, ISingleResultSpecification
    {
        /// <summary>
        /// Buscar un cliente por codigoPersona y estado
        /// </summary>
        /// <param name="codigoPersona">codigoPersona de cliente a ser buscado</param>
        /// <param name="estado">Estado a ser buscado por defecto es (A)ctivo</param>
        public ClienteSpec(int codigoPersona, string estado)
        {
            Query.Where(h => h.IdPersona == codigoPersona && h.Estado == estado);
        }

        /// <summary>
        /// Buscar un cliente por Id IdCliente y estado (A)ctivo
        /// </summary>
        /// <param name="codigoPersona">codigoPersona de cliente a ser buscado</param>
        public ClienteSpec(int codigoCliente)
        {
            Query.Where(h => h.IdCliente == codigoCliente && h.Estado == "A");
        }
    }
}
