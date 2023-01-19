using CQRSImplementation.Application.Features.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSImplementation.API.Controllers
{
    [Route("[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator _mediator)
        {
            this.mediator = _mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {

            return Ok(await mediator.Send(command));

        }
    }
}
