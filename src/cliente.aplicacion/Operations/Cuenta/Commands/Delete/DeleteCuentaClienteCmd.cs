using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Cuenta.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Cuenta.Commands.Delete
{
    public class DeleteCuentaClienteCmd : IRequest<ResponseCliente<List<int>>>
    {
        public int IdCliente { get; set; }

    }

    public class DeleteCuentaClienteHandler : IRequestHandler<DeleteCuentaClienteCmd, ResponseCliente<List<int>>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.ClienteCuenta> repository;
        private readonly IMapper mapper;

        public DeleteCuentaClienteHandler(IRepositoryAsync<dominio.Entities.bp_cliente.ClienteCuenta> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<List<int>>> Handle(DeleteCuentaClienteCmd request, CancellationToken cancellationToken)
        {
            var especEstado = new ClienteCuentasSpec(request.IdCliente);
            var registros= await repository.ListAsync(especEstado, cancellationToken);

            if (registros == null)
                throw new KeyNotFoundException($"El cliente no tiene cuentas activas: {request.IdCliente}");

            foreach (var registro in registros)
            {
                await repository.DeleteAsync(registro, cancellationToken);
            }
                       
            return new ResponseCliente<List<int>>(registros.Select(x=> x.IdCuenta).ToList());
        }
    }

}
