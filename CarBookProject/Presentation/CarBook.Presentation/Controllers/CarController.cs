using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly IMediator _mediator;
        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _mediator.Send(new GetCarQuery());
            return Ok(value);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCarWithBrands()
        {
            var value = await _mediator.Send(new GetCarWithBrandsQuery());
            return Ok(value);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetCarByIdQuery(id));
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CreateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("EKlendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(UpdateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new RemoveCarCommand(id));
            return Ok("Silindi");
        }
    }
}

