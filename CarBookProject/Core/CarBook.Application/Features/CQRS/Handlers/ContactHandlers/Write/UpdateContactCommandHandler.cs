using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write
{
    public class UpdateContactCommandHandler
	{
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id);
            category.Name = command.Name;
            await _repository.UpdateAsync(category);
        }
    }
}

