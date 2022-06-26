using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Cliente.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Cliente.Commands.Delete
{
    public class DeleteClienteIdPersonaCmd : IRequest<ResponseCliente<int>>
    {
        public int IdPersona { get; set; }

    }

    public class DeleteClienteIdPersonaCmdHandler : IRequestHandler<DeleteClienteIdPersonaCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Cliente> repository;
        private readonly IMapper mapper;

        public DeleteClienteIdPersonaCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Cliente> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(DeleteClienteIdPersonaCmd request, CancellationToken cancellationToken)
        {
            var especEstado = new ClienteSpec(request.IdPersona, "A");
            var registro = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registro == null)
                throw new KeyNotFoundException($"La persona no esta registrado como cliente: {request.IdPersona}");

            await repository.DeleteAsync(registro, cancellationToken);
            return new ResponseCliente<int>(registro.IdCliente);
        }
    }
}
