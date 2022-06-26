using cliente.aplicacion.Operations.Cuenta.Commands.Delete;
using cliente.aplicacion.Operations.Cuenta.Commands.Insert;
using cliente.aplicacion.Operations.Cuenta.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace cliente.api.Controllers.v1
{
    [Route("/cuentas/")]
    public class CuentaController : BaseApiController
    {

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GuardarCliente(InsertCuentaCmd cuenta)
        {
            var a = await Mediator.Send(cuenta);
            cuenta.Cliente.IdCuenta = a.Data;
            return Ok(await Mediator.Send(cuenta.Cliente));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> ActualizarCliente(UpdateCuentaCmd cuenta)
        {
            return Ok(await Mediator.Send(cuenta));
        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> EliminarCliente(DeleteCuentaPorIdCmd cuenta)
        {
            return Ok(await Mediator.Send(cuenta));
        }
    }
}
