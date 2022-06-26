using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cliente.api.Controllers
{
    [ApiController]
    [Area("api/v{version:apiVersion}")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator meddiator;
        protected IMediator Mediator => meddiator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
