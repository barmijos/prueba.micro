using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Persona.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Persona.Commands.Delete
{
    public class DeletePersonaCmd: IRequest<ResponseCliente<int>>
    {
        public int IdPersona { get; set; }
    }

    public class DeleteClienteCmdHandler : IRequestHandler<DeletePersonaCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Persona> repository;
        private readonly IMapper mapper;

        public DeleteClienteCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Persona> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(DeletePersonaCmd request, CancellationToken cancellationToken)
        {
            var especEstado = new PersonaSpec(request.IdPersona);
            var registro = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registro == null)
                throw new KeyNotFoundException($"La persona no existe: {request.IdPersona}");

            await repository.DeleteAsync(registro, cancellationToken);
            return new ResponseCliente<int>(registro.IdPersona);
        }
    }
}
