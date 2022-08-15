using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Tundra.Presentation.API.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        private ISender mediator;
        protected ISender Mediator => this.mediator ??= this.HttpContext.RequestServices.GetService<ISender>();
    }
}
