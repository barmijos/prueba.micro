using cliente.aplicacion.Interfaces;
using cliente.comun.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cliente.comun.Extensions
{
    public static class ClienteComunExtensions
    {
        /// <summary>
        /// Ingresar la configuracion para obtener extensiones de uso general
        /// </summary>
        /// <param name="service">Servicio a configurar usando DI</param>
        /// <param name="configuration"></param>
        public static void AddClienteComunExtensions(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IMontoMaximo, CupoMaximoRetiro>();
        }
    }
}
