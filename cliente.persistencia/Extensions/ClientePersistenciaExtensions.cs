using cliente.aplicacion.Interfaces;
using cliente.persistencia.Context;
using cliente.persistencia.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cliente.persistencia.Extensions
{
    public static class ClientePersistenciaExtensions
    {
        private const string Conexion_Cliente ="ConexionCliente";

        public static void AddClientePersistenciaExtensions(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDBContext>(opt => opt.UseSqlServer(
                configuration.GetConnectionString(Conexion_Cliente),
                opt => opt.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

            service.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositorioAsync<>));
        }
    }
}
