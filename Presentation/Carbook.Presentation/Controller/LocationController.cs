using Carbook.Application.Features.CQRS.Commands.LocationCommands;
using Carbook.Application.Features.CQRS.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Presentation.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly IMediator _mediator;
        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var value = await _mediator.Send(new GetLocationQuery());
            return Ok(value);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(string id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("EKlendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult>Put(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Silindi");
        }
    }
}
