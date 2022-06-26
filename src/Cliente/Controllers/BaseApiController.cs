using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cliente.api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator meddiator;
        protected IMediator Mediator => meddiator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
