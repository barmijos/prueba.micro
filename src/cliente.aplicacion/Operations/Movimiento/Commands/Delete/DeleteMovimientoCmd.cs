using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Movimiento.Querys;
using cliente.aplicacion.Wrappers;
using MediatR;

namespace cliente.aplicacion.Operations.Movimiento.Commands.Delete
{
    public class DeleteMovimientoCmd : IRequest<ResponseCliente<int>>
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        
    }

    public class DeleteMovimientoCmdHandler : IRequestHandler<DeleteMovimientoCmd, ResponseCliente<int>>
    {
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Movimiento> repository;
        private readonly IMapper mapper;

        public DeleteMovimientoCmdHandler(IRepositoryAsync<dominio.Entities.bp_cliente.Movimiento> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ResponseCliente<int>> Handle(DeleteMovimientoCmd request, CancellationToken cancellationToken)
        {
            var especEstado = new MovimientoSpec(request.IdMovimiento, request.IdCuenta);
            var registro = await repository.GetBySpecAsync(especEstado, cancellationToken);

            if (registro == null)
                throw new KeyNotFoundException($"El movimiento no existe: {request.IdMovimiento}");

            await repository.DeleteAsync(registro, cancellationToken);
            return new ResponseCliente<int>(registro.IdMovimiento);
        }
    }
}
