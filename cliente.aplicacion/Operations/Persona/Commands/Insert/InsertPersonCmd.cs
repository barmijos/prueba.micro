using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Persona.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Persona.Commands.Insert
{
    public class InsertPersonCmd : IRequest<ResponseCliente<int>>
    {
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public char Genero { get; set; }
        public int Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }

    public class InsertPersonCmdHandler : IRequestHandler<InsertPersonCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Persona> repository;
        private readonly IMapper mapper;

        public InsertPersonCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Persona> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(InsertPersonCmd request, CancellationToken cancellationToken)
        {
            var registro = mapper.Map<dominio.Entities.bp_cliente.Persona>(request);

            var especEstado = new PersonaSpec(request.Identificacion);
            var registroActual = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registroActual != null)
                throw new KeyNotFoundException("El cliente ya existe");

            var data = await repository.AddAsync(registro);
            return new ResponseCliente<int>(data.IdPersona);
        }
    }
}
