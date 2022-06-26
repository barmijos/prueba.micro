using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Movimiento.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Movimiento.Commands.Update
{
    public class UpdateMovimientoCmd : IRequest<ResponseCliente<int>>
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public decimal ValorMovimiento { get; set; }
        public decimal SaldoCuenta { get; set; }
    }

    public class UpdateMovimientoCmdHandler : IRequestHandler<UpdateMovimientoCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Movimiento> repository;
        private readonly IMapper mapper;

        public UpdateMovimientoCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Movimiento> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(UpdateMovimientoCmd request, CancellationToken cancellationToken)
        {
            var especEstado = new MovimientoSpec(request.IdMovimiento, request.IdCuenta);
            var registro = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registro == null)
                throw new KeyNotFoundException($"El movimiento no existe {request.IdMovimiento}");

            var saldoActual = ObtenerSaldo(registro.ValorMovimiento, request.ValorMovimiento, registro.SaldoCuenta);

            registro.TipoMovimiento = request.TipoMovimiento;
            registro.FechaMovimiento = request.FechaMovimiento;
            registro.ValorMovimiento = request.ValorMovimiento;
            registro.SaldoCuenta = saldoActual;

            await repository.UpdateAsync(registro, cancellationToken);
            return new ResponseCliente<int>(registro.IdMovimiento);
        }

        private decimal ObtenerSaldo(decimal valorMovimientoActual, decimal valorMovimientoNuevo, decimal saldoActual)
        {
           var diferencia = valorMovimientoActual - valorMovimientoNuevo;
            if (diferencia < 0)
                saldoActual += Math.Abs(diferencia); //debo acreditar el saldo
            else if (diferencia > 0)
                saldoActual -= diferencia; // debo debitar el saldo

            return saldoActual;
         }
    }
}
