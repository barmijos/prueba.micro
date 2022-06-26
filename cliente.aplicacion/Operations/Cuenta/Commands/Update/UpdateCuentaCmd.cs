using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Cuenta.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Cuenta.Commands.Update
{
    public class UpdateCuentaCmd : IRequest<ResponseCliente<int>>
    {
        public int IdCuenta { get; set; }
        public string NumeroCuenta { get; set; } = null!;
        public string TipoCuenta { get; set; } = null!;
        public decimal SaldoInicial { get; set; }
    }

    public class InsertCuentaCmdHandler : IRequestHandler<UpdateCuentaCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Cuenta> repository;
        private readonly IMapper mapper;

        public InsertCuentaCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Cuenta> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(UpdateCuentaCmd request, CancellationToken cancellationToken)
        {
             var especEstado = new CuentaSpec(request.IdCuenta, "A");
            var registroActual = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registroActual  == null)
                throw new KeyNotFoundException($"La cuenta no existe o esta deshabilitada:{request.IdCuenta}");

            registroActual.NumeroCuenta = request.NumeroCuenta;
            registroActual.TipoCuenta = request.TipoCuenta;
            registroActual.SaldoInicial = request.SaldoInicial;

            await repository.UpdateAsync(registroActual);
            return new ResponseCliente<int>(registroActual.IdCuenta);
        }
    }
}
