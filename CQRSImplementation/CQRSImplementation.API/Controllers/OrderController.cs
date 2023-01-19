using CQRSImplementation.Application.Features.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSImplementation.API.Controllers
{

    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {

            return Ok(await mediator.Send(command));

        }
    }
}
