using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _mediator.Send(new GetBlogQuery());
            return Ok(value);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get3BlogWithAuthor()
        {
            var value = await _mediator.Send(new Get3BlogWithAuthorQuery());
            return Ok(value);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBlogWithAuthorByBlogId(string id)
        {
            var value = await _mediator.Send(new GetBlogWithAuthorByBlogIdQuery(id));
            return Ok(value);
        }
   

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBlogWithAuthor()
        {
            var value = await _mediator.Send(new GetAllBlogWithAuthorQuery());
            return Ok(value);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("EKlendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Silindi");
        }
    }
}

