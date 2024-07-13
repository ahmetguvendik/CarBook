using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : Controller
    {
        private readonly IMediator _mediator;
        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var value = await _mediator.Send(new GetFeatureQuery());
            return Ok(value);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(string id)
        {
            var value = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("EKlendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult>Put(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Silindi");
        }
    }
}

