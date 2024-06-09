using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Write;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBook.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly CreataContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;

        public ContactController(CreataContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, GetContactQueryHandler getContactQueryHandler, GetContactByIdQueryHandler getContactByIdQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var values = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Eklendi");
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Guncellendi");
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Silindi");
        }
    }
}

