using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : Controller
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly DeleteAboutCommandHandler _deleteAboutCommandHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;

        public AboutController(CreateAboutCommandHandler createAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler, DeleteAboutCommandHandler deleteAboutCommandHandler, GetAboutQueryHandler getAboutQueryHandler, GetAboutByIdQueryHandler getAboutByIdQueryHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _deleteAboutCommandHandler = deleteAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAbout()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var values = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAbout(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("Eklendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult>PutAbout(UpdateAboutCommand command)
        {
           await _updateAboutCommandHandler.Handle(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _deleteAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("Silindi");
        }
    }
}

