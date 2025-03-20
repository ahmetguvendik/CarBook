using Carbook.Application.Features.CQRS.Commands.ContactCommands;
using Carbook.Application.Features.CQRS.Queries.ContactQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _mediator.Send(new GetContactQuery());
            return Ok(value);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetContactByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("{action}")]
        public async Task<IActionResult> GetContactByBlogId(string id)
        {
            var value = await _mediator.Send(new GetContactByIdQuery(id));
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CreateContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("EKlendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(UpdateContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new RemoveContactCommand(id));
            return Ok("Silindi");
        }
    }
}

