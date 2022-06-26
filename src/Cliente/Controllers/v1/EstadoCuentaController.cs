using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Movimiento.Querys;
using Microsoft.AspNetCore.Mvc;

namespace cliente.api.Controllers.v1
{
    [ApiVersion("1.0")]
   // [Route("[area]/reportes")]
    public class EstadoCuentaController : BaseApiController
    {
        private readonly IMontoMaximo montoMaximo;

        public EstadoCuentaController(IMontoMaximo montoMaximo)
        {
            this.montoMaximo = montoMaximo;
        }

        [HttpGet]
        [Route("[area]/reportes/estado-cuenta")]
        public async Task<IActionResult> ObtenerEstadoCuenta([FromQuery] GenerarEstadosCuentaParameters filters)
        {
            GenerarEstadoCuentaQuery cliente = new GenerarEstadoCuentaQuery()
            {
                NumeroPagina = filters.NumeroPagina,
                NumeroRegistros = filters.NumeroRegistros,
                IdCliente = filters.IdCliente,
                FechaInicio = filters.FechaInicio.HasValue ? filters.FechaInicio.Value : montoMaximo.FechaProceso,
                FechaFin = filters.FechaFin.HasValue ? filters.FechaFin.Value : montoMaximo.FechaSiguiente
            };
            
            return Ok(await Mediator.Send(cliente));
        }
    }
}
