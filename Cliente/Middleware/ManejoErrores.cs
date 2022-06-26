using cliente.aplicacion.Error;
using cliente.aplicacion.Wrappers;
using System.Text.Json;

namespace cliente.api.middleware
{
    public class ManejoErrores
    {
        private readonly RequestDelegate _request;

        public ManejoErrores(RequestDelegate request)
        {
            _request = request;
        }
        /// <summary>
        /// Personalizacion de errores que van a ser enviados por el Api
        /// </summary>
        /// <param name="httpContext">Contexto de ejecucion de la peticion http</param>
        /// <returns>Task con la siguiente ejecucion disponible</returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _request(httpContext);
            }
            catch (Exception err)
            {
                var respuesta = httpContext.Response;
                respuesta.Headers.Clear();
                respuesta.ContentType = "application/json";
                var respuestaServicio = new ResponseCliente<string>() { Success = false, Message = err.Message };

                switch (err)
                {
                    case ApiException e:
                        respuesta.StatusCode = 460;
                        break;
                    case ValidacionException e:
                        respuesta.StatusCode = 461;
                        respuestaServicio.Errors = e.Errores;
                        break;
                    case KeyNotFoundException e:
                        respuesta.StatusCode = 462;
                        break;
                    default:
                        respuesta.StatusCode = 463;
                        break;
                }
                var tramaResultado = JsonSerializer.Serialize(respuestaServicio);
                await respuesta.WriteAsync(tramaResultado);
            }
        }
    }
}
