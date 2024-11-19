using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : Controller
    {
        private readonly IMediator _mediator;
        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _mediator.Send(new GetPricingQuery());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetPricingQueryByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Silindi");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Guncellendi");
        }
    }
}

