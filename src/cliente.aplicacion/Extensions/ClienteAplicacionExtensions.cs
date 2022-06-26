using cliente.aplicacion.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace cliente.aplicacion.Extensions
{
    public static class ClienteAplicacionExtensions
    {
        /// <summary>
        /// Ingresa las configuraciones de la capa de aplicacion
        /// </summary>
        /// <param name="services">servicio a ser configurado usando DI</param>
        public static void AddClienteAplicacionExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly()); 
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidacionPipeline<,>));
        }
    }
}
