using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Cliente.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Cliente.Commands.Insert
{
    public class InsertClienteCmd : IRequest<ResponseCliente<int>>
    {
        public int IdPersona { get; set; }
        public string Contrasena { get; set; } = null!;
    }

    public class InsertClientCmdHandler : IRequestHandler<InsertClienteCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Cliente> repository;
        private readonly IMapper mapper;

        public InsertClientCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Cliente> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(InsertClienteCmd request, CancellationToken cancellationToken)
        {
            var registro = mapper.Map<dominio.Entities.bp_cliente.Cliente>(request);

            var especEstado = new ClienteSpec(request.IdPersona, "A");
            var registroActual = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registroActual != null)
                throw new KeyNotFoundException("El cliente ya existe");

            var data = await repository.AddAsync(registro);
            return new ResponseCliente<int>(data.IdPersona);
        }
    }
}
