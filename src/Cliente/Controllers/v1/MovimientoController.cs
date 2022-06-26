using cliente.aplicacion.Operations.Movimiento.Commands.Delete;
using cliente.aplicacion.Operations.Movimiento.Commands.Insert;
using cliente.aplicacion.Operations.Movimiento.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace cliente.api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("[area]/movimientos/")]
    public class MovimientoController : BaseApiController
    {
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GuardarCliente(InsertMovimientoCmd movimiento)
        {
            return Ok(await Mediator.Send(movimiento));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> ActualizarCliente(UpdateMovimientoCmd movimiento)
        {
            return Ok(await Mediator.Send(movimiento));
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> EliminarCliente(DeleteMovimientoCmd movimiento)
        {
            return Ok(await Mediator.Send(movimiento));
        }
    }
}
