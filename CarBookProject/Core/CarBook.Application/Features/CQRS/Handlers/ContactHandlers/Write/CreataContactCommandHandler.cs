using System;
using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write
{
	public class CreataContactCommandHandler
	{
		private readonly IRepository<Contact> _repository;
		public CreataContactCommandHandler(IRepository<Contact> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateContactCommand command)
		{
			var contact = new Contact();
			contact.Id = Guid.NewGuid().ToString();
			contact.Name = command.Name;
			contact.Subject = command.Subject;
			contact.Email = command.Email;
			contact.Description = command.Description;
			contact.DateTime = DateTime.UtcNow;
			await _repository.CreateAsync(contact);
		}
	}
}

