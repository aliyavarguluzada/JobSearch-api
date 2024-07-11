using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IMediator Mediator { get => _mediator ?? HttpContext.RequestServices.GetRequiredService<IMediator>(); }
    }
}
