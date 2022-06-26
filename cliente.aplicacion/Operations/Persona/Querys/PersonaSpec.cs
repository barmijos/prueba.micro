using Ardalis.Specification;

namespace cliente.aplicacion.Operations.Persona.Querys
{
    internal class PersonaSpec : Specification<dominio.Entities.bp_cliente.Persona>, ISingleResultSpecification
    {
        /// <summary>
        /// Buscar un cliente por codigo y estado
        /// </summary>
        /// <param name="codigo">codigo de persona a ser buscado</param>
        public PersonaSpec(int codigo)
        {
            Query.Where(h => h.IdPersona == codigo);
        }

        /// <summary>
        /// Buscar un cliente por codigo y estado
        /// </summary>
        /// <param name="codigo">codigo de cliente a ser buscado</param>
        public PersonaSpec(string identificacion)
        {
            Query.Where(h => h.Identificacion == identificacion);
        }
    }
}
