using AutoMapper;
using cliente.aplicacion.Interfaces;
using cliente.aplicacion.Operations.Cliente.Querys;
using cliente.aplicacion.Operations.Cuenta.Querys;
using cliente.aplicacion.Operations.Persona.Querys;
using cliente.aplicacion.Wrappers;
using cliente.dominio.Entities.bp_cliente;
using cliente.dominio.Entities.EstadoCuenta;
using MediatR;

namespace cliente.aplicacion.Operations.Movimiento.Querys
{
    public class GenerarEstadoCuentaQuery : IRequest<ResponseMovimiento<ClienteFecha>>
    {
        /// <summary>
        /// Que pagina quiero
        /// </summary>
        public int NumeroPagina { get; set; } = 1;
        /// <summary>
        /// Cuantos registros por pagina
        /// </summary>
        public int NumeroRegistros { get; set; } = 10;

        public int IdCliente { get; set; } 
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public DateTime FechaFin { get; set; } = DateTime.Now;
    }

    public class GenerarEstadoCuentaQueryHandler : IRequestHandler<GenerarEstadoCuentaQuery, ResponseMovimiento<ClienteFecha>>
    {

        private readonly IMapper mapper;
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Cliente> repositoryClient;
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.ClienteCuenta> repositoryClientCuenta;
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Cuenta> repositoryCuenta;
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Movimiento> repositoryMovimiento;
        private readonly IRepositoryAsync<dominio.Entities.bp_cliente.Persona> repositoryPersona;

        public GenerarEstadoCuentaQueryHandler(IMapper mapper,
                                               IRepositoryAsync<dominio.Entities.bp_cliente.Cliente> repositoryClient,
                                               IRepositoryAsync<ClienteCuenta> repositoryClientCuenta,
                                               IRepositoryAsync<dominio.Entities.bp_cliente.Cuenta> repositoryCuenta,
                                               IRepositoryAsync<dominio.Entities.bp_cliente.Movimiento> repositoryMovimiento,
                                               IRepositoryAsync<dominio.Entities.bp_cliente.Persona> repositoryPersona)
        {
            this.mapper = mapper;
            this.repositoryClient = repositoryClient;
            this.repositoryClientCuenta = repositoryClientCuenta;
            this.repositoryCuenta = repositoryCuenta;
            this.repositoryMovimiento = repositoryMovimiento;
            this.repositoryPersona = repositoryPersona;
        }

        public async Task<ResponseMovimiento<ClienteFecha>> Handle(GenerarEstadoCuentaQuery request, CancellationToken cancellationToken)
        {
            ClienteFecha clienteFecha = new ClienteFecha();
            clienteFecha.FechaFin = request.FechaFin;
            clienteFecha.FechaInicio = request.FechaInicio;

            var especificacionCliente = new ClienteSpec(request.IdCliente);
            var cliente =  await repositoryClient.GetBySpecAsync(especificacionCliente);

            var especificacionPersona = new PersonaSpec(cliente.IdPersona);
            var persona = await repositoryPersona.GetBySpecAsync(especificacionPersona);

            clienteFecha.Nombre = persona.Nombre;

            var espificicacionClienteCuenta = new ClienteCuentasSpec(request.IdCliente);
            var clienteCuentas = await repositoryClientCuenta.ListAsync(espificicacionClienteCuenta);

            CuentaSpec espificicacionCuenta;
            MovimientosCuenta especificacionMovimientoCuenta;
            foreach (var item in clienteCuentas)
            {
                espificicacionCuenta = new CuentaSpec(item.IdCuenta);
                var cuenta = await repositoryCuenta.GetBySpecAsync(espificicacionCuenta);

                especificacionMovimientoCuenta = new MovimientosCuenta(cuenta.IdCuenta, request.FechaInicio, request.FechaFin);
                var movimientos = await repositoryMovimiento.ListAsync(especificacionMovimientoCuenta);

                

                ReporteSaldoMovimiento reporteSaldoMovimiento = new ReporteSaldoMovimiento();
                reporteSaldoMovimiento.NumeroCuenta = cuenta.NumeroCuenta;
                reporteSaldoMovimiento.TipoCuenta = cuenta.TipoCuenta;

                reporteSaldoMovimiento.Saldo = movimientos.Sum(x=> x.ValorMovimiento);
                reporteSaldoMovimiento.SaldoCredito = movimientos.Where(x=> x.TipoMovimiento != "DEB").Sum(x => x.ValorMovimiento);
                reporteSaldoMovimiento.SaldoDebito = movimientos.Where(x => x.TipoMovimiento == "DEB").Sum(x => x.ValorMovimiento);

                reporteSaldoMovimiento.Movimientos = movimientos.Select(x => new ReporteMovimiento()
                {
                    FechaTransaccion = x.FechaMovimiento,
                    TipoTransaccion = x.TipoMovimiento,
                    MontoMovimiento = x.ValorMovimiento
                }).ToList();



                clienteFecha.TotalesCuenta.Add(reporteSaldoMovimiento);
            }

            return new ResponseMovimiento<ClienteFecha>(clienteFecha, request.NumeroPagina, request.NumeroRegistros); ;
        }
    }
}
