using cliente.aplicacion.Error;
using FluentValidation;
using MediatR;

namespace cliente.aplicacion.Behaviors
{
    public class ValidacionPipeline<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validator;

        public ValidacionPipeline(IEnumerable<IValidator<TRequest>> validator)
        {
            this.validator = validator;
        }

        /// <summary>
        /// Metodo para ejecutar las validaciones de fluente en las clases
        /// </summary>
        /// <param name="request">Objeto enviado a validar</param>
        /// <param name="cancellationToken">terminar la tarea asyn</param>
        /// <param name="next">siguiente tarea de ejecucion en el pipeline</param>
        /// <returns>el siguiente pipeline de ejecucion</returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(!validator.Any())
                return await next();

            var contexto = new ValidationContext<TRequest>(request);
            var resultado = await Task.WhenAll(validator.Select(err => err.ValidateAsync(contexto, cancellationToken)));
            var errores = resultado.SelectMany(msg => msg.Errors).Where(msg => msg != null).ToList();
            if(errores.Any())
                throw new ValidacionException(errores);
            return await next();
        }
    }
}
