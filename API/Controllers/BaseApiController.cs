using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly IMediator Mediator;
        public BaseApiController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
