using AutoMapper;
using cliente.dominio.Entities.bp_cliente;

namespace cliente.aplicacion.Mappings
{
    public class ClienteProfiler : Profile
    {
        public ClienteProfiler()
        {
            // mapeo para la operaci[on de insercion
            CreateMap<Operations.Cliente.Commands.Insert.InsertClienteCmd, Cliente>();
            CreateMap<Operations.Cuenta.Commands.Insert.InsertCuentaCmd, Cuenta>();
            CreateMap<Operations.Persona.Commands.Insert.InsertPersonCmd, Persona>();
            CreateMap<Operations.Cuenta.Commands.Insert.InsertCuentaClienteCmd, ClienteCuenta>();
            CreateMap<Operations.Movimiento.Commands.Insert.InsertMovimientoCmd, Movimiento>();
        }
    }
}
