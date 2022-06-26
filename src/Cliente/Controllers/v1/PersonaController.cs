using cliente.aplicacion.Operations.Cliente.Commands.Delete;
using cliente.aplicacion.Operations.Cuenta.Commands.Delete;
using cliente.aplicacion.Operations.Persona.Commands.Delete;
using cliente.aplicacion.Operations.Persona.Commands.Insert;
using cliente.aplicacion.Operations.Persona.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace cliente.api.Controllers.v1
{
    [Route("/personas/")]
    public class PersonaController : BaseApiController
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GuardarCliente(InsertPersonCmd cliente)
        {
            return Ok(await Mediator.Send(cliente));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> ActualizarCliente(UpdatePersonCmd cliente)
        {
            return Ok(await Mediator.Send(cliente));
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> EliminarCliente(DeletePersonaCmd cliente)
        {

            DeleteClienteIdPersonaCmd deleteClienteIdPersona = new DeleteClienteIdPersonaCmd();
            deleteClienteIdPersona.IdPersona = cliente.IdPersona;
            var idCliente = await Mediator.Send(deleteClienteIdPersona); //elimino las relaciones

            DeleteCuentaClienteCmd deleteCuentaCliente = new DeleteCuentaClienteCmd();
            deleteCuentaCliente.IdCliente = idCliente.Data;
            var cuentasBorra = await Mediator.Send(deleteCuentaCliente); //elimino las relaciones

            DeleteCuentaPorIdCmd deleteCuenta = new DeleteCuentaPorIdCmd();
            foreach (var item in cuentasBorra.Data)
            {
                deleteCuenta.IdCuenta = item;
                await Mediator.Send(deleteCuenta); //elimino las cuentas
            }

            return Ok(cliente);
        }
    }
}
