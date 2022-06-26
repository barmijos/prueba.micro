using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Cuenta.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Cuenta.Commands.Insert
{
    public class InsertCuentaClienteCmd : IRequest<ResponseCliente<int>>
    {
        public int? IdCuenta { get; set; }
        public int IdCliente { get; set; }
        public string ClaveCliente { get; set; } = null!;
    }

    public class InsertCuentaClienteCmdHandler : IRequestHandler<InsertCuentaClienteCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.ClienteCuenta> repository;
        private readonly IMapper mapper;

        public InsertCuentaClienteCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.ClienteCuenta> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(InsertCuentaClienteCmd request, CancellationToken cancellationToken)
        {
            var registro = mapper.Map<dominio.Entities.bp_cliente.ClienteCuenta>(request);

            var especEstado = new ClienteCuentaSpec(request.IdCuenta.Value, request.IdCliente);
            var registroActual = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registroActual != null)
                throw new KeyNotFoundException("El cuenta ya existe");

            var data = await repository.AddAsync(registro);

            return new ResponseCliente<int>(data.IdCuenta);
        }
    }
}
