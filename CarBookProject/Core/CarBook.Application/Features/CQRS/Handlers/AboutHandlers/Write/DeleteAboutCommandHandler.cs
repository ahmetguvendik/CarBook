using System;
using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write
{
	public class DeleteAboutCommandHandler
	{
		private readonly IRepository<About> _repository;
		public DeleteAboutCommandHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveAboutCommand command)
		{
			var about = await _repository.GetByIdAsync(command.id);
			await _repository.RemoveAsync(about);
		}
	}
}

