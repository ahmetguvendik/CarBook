using System;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write
{
	public class RemoveContactCommandHandler
	{
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(category);

        }
    }
}

