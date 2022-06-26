using cliente.api.middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace cliente.api.Extensions
{
    public static class ClienteApiExtensions
    {
        private const string Api_Version = "api-version";
        private const string Header_Version = "x-version";
        private const string Media_Type = "media-version";

        public static void UseErrorsHandlerMiddlware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ManejoErrores>();

        }

        public static void AddApiVersionExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.ReportApiVersions = true;

                
                opt.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader(Api_Version),
                    new HeaderApiVersionReader(Header_Version),
                    new MediaTypeApiVersionReader(Media_Type));
            });
        }
    }
}
