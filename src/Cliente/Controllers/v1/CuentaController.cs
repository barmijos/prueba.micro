using cliente.aplicacion.Operations.Cuenta.Commands.Delete;
using cliente.aplicacion.Operations.Cuenta.Commands.Insert;
using cliente.aplicacion.Operations.Cuenta.Commands.Update;
using cliente.aplicacion.Operations.Movimiento.Commands.Insert;
using Microsoft.AspNetCore.Mvc;

namespace cliente.api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("[area]/cuentas/")]
    public class CuentaController : BaseApiController
    {

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GuardarCliente(InsertCuentaCmd cuenta)
        {
            var a = await Mediator.Send(cuenta); //cuenta
            cuenta.Cliente.IdCuenta = a.Data;
            await Mediator.Send(cuenta.Cliente); //cuenta cliente

            InsertMovimientoCmd objMovimiento = new InsertMovimientoCmd();
            objMovimiento.IdCuenta = a.Data;
            objMovimiento.FechaMovimiento = DateTime.Now;
            objMovimiento.ValorMovimiento = cuenta.SaldoInicial;
            objMovimiento.TipoMovimiento = "CRED";

            return Ok(await Mediator.Send(objMovimiento)); //movimiento
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
