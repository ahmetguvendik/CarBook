using CarBook.Application.Features.Mediator.Commands.CommetCommands;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _mediator.Send(new GetCommentQuery());
            return Ok(value);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCommentByBlogId(string id)
        {
            var value = await _mediator.Send(new GetCommentsWithBlogIdQuery(id));
            return Ok(value);
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCommentsWithBlogTitle()
        {
            var values = await _mediator.Send(new GetCommentWithBlogTitleQuery());
            return Ok(values);
        }


        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("EKlendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Silindi");
        }
    }
}

