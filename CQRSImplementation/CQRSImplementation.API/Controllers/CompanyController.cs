using CQRSImplementation.Application.Features.Command;
using CQRSImplementation.Application.Features.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSImplementation.API.Controllers
{

    [Route("[controller]/[Action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var query = new GetAllCompanyQuery();

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyAsync(CreateCompanyCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompanyAsync(UpdateCompanyCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
