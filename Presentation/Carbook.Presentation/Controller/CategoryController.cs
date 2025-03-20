using Carbook.Application.Features.CQRS.Commands.CategoryCommands;
using Carbook.Application.Features.CQRS.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
       
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            var value = await _mediator.Send(new GetCategoryQuery());
            return Ok(value);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var value = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("{action}")]
        public async Task<IActionResult> GetCategoryByBlogId(string id)
        {
            var value = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("EKlendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return Ok("Silindi");
        }
    }
}

