using System;
using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write
{
	public class UpdateAboutCommandHandler
	{
		private readonly IRepository<About> _repository;
		public UpdateAboutCommandHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateAboutCommand command)
		{
			var about = await _repository.GetByIdAsync(command.id);
			about.Description = command.Description;
			about.ImageURL = command.ImageURL;
			about.Title = command.Title;
			await _repository.UpdateAsync(about);
		}
	}
}

