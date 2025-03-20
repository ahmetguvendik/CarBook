using Carbook.Application.Features.CQRS.Commands.AboutCommands;
using Carbook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using CarBook.Application.Features.Mediator.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : Controller
    {
        private readonly IMediator _mediator;
        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _mediator.Send(new GetAboutQuery());
            return Ok(value);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetAboutByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("{action}")]
        public async Task<IActionResult> GetAboutByBlogId(string id)
        {
            var value = await _mediator.Send(new GetAboutByIdQuery(id));
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CreateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok("EKlendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(UpdateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new RemoveAboutCommand(id));
            return Ok("Silindi");
        }     
    }
    
    }

