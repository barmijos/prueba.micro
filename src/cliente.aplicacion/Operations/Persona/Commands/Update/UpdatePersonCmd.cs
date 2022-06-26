using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Persona.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Persona.Commands.Update
{
    public class UpdatePersonCmd : IRequest<ResponseCliente<int>>
    {
        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public char Genero { get; set; }
        public short Edad { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }

    public class UpdatePersonCmdHandler : IRequestHandler<UpdatePersonCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Persona> repository;
        private readonly IMapper mapper;

        public UpdatePersonCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Persona> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(UpdatePersonCmd request, CancellationToken cancellationToken)
        {
            var especEstado = new PersonaSpec(request.IdPersona);
            var registro = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registro == null)
                throw new KeyNotFoundException("Error en el registro a actualizar");

            registro.Nombre = request.Nombre;
            registro.Identificacion = request.Identificacion;
            registro.Genero = request.Genero;
            registro.Edad = request.Edad;
            registro.Telefono = request.Telefono;
            registro.Direccion = request.Direccion;
            
            await repository.UpdateAsync(registro, cancellationToken);
            return new ResponseCliente<int>(registro.IdPersona);
        }
    }
}
