using AutoMapper;
using cliente.aplicacion.Error;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Movimiento.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Movimiento.Commands.Insert
{
    public class InsertMovimientoCmd : IRequest<ResponseCliente<int>>
    {
        public int IdCuenta { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string TipoMovimiento { get; set; } = null!;
        public decimal ValorMovimiento { get; set; }
        public decimal SaldoCuenta { get; set; }
    }

    public class InsertMovimientoCmdHandler : IRequestHandler<InsertMovimientoCmd, ResponseCliente<int>>
    {
        private const string Nemonico_Debito = "DEB";
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Movimiento> repository;
        private readonly IMapper mapper;
        private readonly IMontoMaximo montoMaximo;

        public InsertMovimientoCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Movimiento> repository, IMapper mapper, IMontoMaximo montoMaximo)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.montoMaximo = montoMaximo;
        }

        public async Task<ResponseCliente<int>> Handle(InsertMovimientoCmd request, CancellationToken cancellationToken)
        {
            var especEstado = new MovimientoSpec(request.IdCuenta, request.FechaMovimiento);
            var registroActual = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registroActual != null)
                throw new KeyNotFoundException($"El movimiento ya existe: {request.IdCuenta} - {request.FechaMovimiento}");

            var registro = mapper.Map<dominio.Entities.bp_cliente.Movimiento>(request);
            var saldoActual = await repository.ListAsync(new MovimientoSpec(request.IdCuenta), cancellationToken);

            ValidarMontos(request);
            ValidarCupoRetiro(saldoActual, request);
            registro.SaldoCuenta = CalcularSaldo(registro, saldoActual);

            var movimiento = await repository.AddAsync(registro, cancellationToken);

            return new ResponseCliente<int>(movimiento.IdMovimiento);
        }

        private static void ValidarMontos(InsertMovimientoCmd request)
        {

            if (request.TipoMovimiento == Nemonico_Debito && request.ValorMovimiento > 0)
                throw new ApiException($"El valor para debitos debe ser negativo: {request.ValorMovimiento}");
            else if (request.TipoMovimiento != Nemonico_Debito && request.ValorMovimiento < 0)
                throw new ApiException($"El valor para creditos debe ser positivo: {request.ValorMovimiento}");
        }

        private void ValidarCupoRetiro(List<dominio.Entities.bp_cliente.Movimiento> saldoActual, InsertMovimientoCmd request)
        {
            if (request.TipoMovimiento != Nemonico_Debito)
                return;

            var cupoOcupado = saldoActual.Where(x => x.TipoMovimiento == Nemonico_Debito && x.FechaMovimiento >= montoMaximo.FechaProceso).Sum(x => x.ValorMovimiento);

            if (Math.Abs(cupoOcupado + request.ValorMovimiento) > montoMaximo.MontoMaximo)
                throw new ApiException("El cupo permitido ha sido excedido");
        }

        private static decimal CalcularSaldo(dominio.Entities.bp_cliente.Movimiento registro, List<dominio.Entities.bp_cliente.Movimiento> saldoActual)
        {
            decimal nuevoSaldo = 0;

            if (saldoActual == null)
                nuevoSaldo = registro.ValorMovimiento;
            else
                nuevoSaldo = saldoActual.Sum(x => x.ValorMovimiento) + registro.ValorMovimiento;

            if (nuevoSaldo < 0)
                throw new ApiException("Fondos insuficientes");

            return nuevoSaldo;
        }
    }
}
