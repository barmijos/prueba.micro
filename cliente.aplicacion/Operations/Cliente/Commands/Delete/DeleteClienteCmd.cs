using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Cliente.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Cliente.Commands.Delete
{
    public class DeleteClienteCmd : IRequest<ResponseCliente<int>>
    {
        public int IdCliente { get; set; }

    }

    public class DeleteClienteCmdHandler : IRequestHandler<DeleteClienteCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Cliente> repository;
        private readonly IMapper mapper;

        public DeleteClienteCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Cliente> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(DeleteClienteCmd request, CancellationToken cancellationToken)
        {
            var especEstado = new ClienteSpec(request.IdCliente);
            var registro = await repository.GetBySpecAsync(especEstado, cancellationToken);
            
            if (registro == null)
                throw new KeyNotFoundException($"El registro es erroneo: {request.IdCliente}");

            await repository.DeleteAsync(registro, cancellationToken);
            return new ResponseCliente<int>(registro.IdPersona);
        }
    }


    
}
