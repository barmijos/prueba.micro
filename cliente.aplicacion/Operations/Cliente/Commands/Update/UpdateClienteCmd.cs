using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Cliente.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Cliente.Commands.Update
{
    public class UpdateClienteCmd : IRequest<ResponseCliente<int>>
    {
        public int IdPersona { get; set; }
        public int IdCliente { get; set; }
        public string Contrasena { get; set; } = null!;
        public string? Estado { get; set; } 
    }

    public class UpdateClientCmdHandler : IRequestHandler<UpdateClienteCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Cliente> repository;
        private readonly IMapper mapper;

        public UpdateClientCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Cliente> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(UpdateClienteCmd request, CancellationToken cancellationToken)
        {
            var especEstado = new ClienteSpec(request.IdCliente);
            var registro = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registro == null)
                throw new KeyNotFoundException("Error en el registro a actualizar");

            registro.Contrasena = request.Contrasena;
            
            await repository.UpdateAsync(registro, cancellationToken);
            return new ResponseCliente<int>(registro.IdPersona);
        }
    }
}
