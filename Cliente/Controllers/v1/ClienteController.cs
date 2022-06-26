using cliente.aplicacion.Operations.Cliente.Commands.Delete;
using cliente.aplicacion.Operations.Cliente.Commands.Insert;
using cliente.aplicacion.Operations.Cliente.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace cliente.api.Controllers.v1
{
    
    [Route("/clientes/")]
    public class ClienteController : BaseApiController
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GuardarCliente(InsertClienteCmd cliente)
        {
            return Ok(await Mediator.Send(cliente));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> ActualizarCliente(UpdateClienteCmd cliente)
        {
            return Ok(await Mediator.Send(cliente));
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> EliminarCliente(DeleteClienteCmd cliente)
        {
            return Ok(await Mediator.Send(cliente));
        }
    }
}
