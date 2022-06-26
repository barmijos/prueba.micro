using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Cuenta.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Cuenta.Commands.Insert
{
    public class InsertCuentaCmd : IRequest<ResponseCliente<int>>
    {
        public string NumeroCuenta { get; set; } = null!;
        public string TipoCuenta { get; set; } = null!;
        public decimal SaldoInicial { get; set; }
        public InsertCuentaClienteCmd Cliente { get; set; } = null!;
    }

    public class InsertCuentaCmdHandler : IRequestHandler<InsertCuentaCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Cuenta> repository;
        private readonly IMapper mapper;

        public InsertCuentaCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Cuenta> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(InsertCuentaCmd request, CancellationToken cancellationToken)
        {
            var registro = mapper.Map<dominio.Entities.bp_cliente.Cuenta>(request);

            var especEstado = new CuentaSpec(request.NumeroCuenta, "A");
            var registroActual = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registroActual != null)
                throw new KeyNotFoundException("El cuenta ya existe");

            var data = await repository.AddAsync(registro);

            return new ResponseCliente<int>(data.IdCuenta);
        }
    }
}
