using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Cuenta.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Cuenta.Commands.Delete
{
    public class DeleteCuentaPorIdCmd : IRequest<ResponseCliente<int>>
    {
        public int IdCuenta { get; set; }
    }

    public class DeleteCuentaCmdHandler : IRequestHandler<DeleteCuentaPorIdCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Cuenta> repository;
        private readonly IMapper mapper;

        public DeleteCuentaCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Cuenta> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(DeleteCuentaPorIdCmd request, CancellationToken cancellationToken)
        {
            var especEstado = new CuentaSpec(request.IdCuenta, "A");
            var registro = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registro == null)
                throw new KeyNotFoundException($"El registro es erroneo: {request.IdCuenta}");

            registro.Estado = "I";

            await repository.UpdateAsync(registro, cancellationToken);
            return new ResponseCliente<int>(registro.IdCuenta);
        }
    }
}