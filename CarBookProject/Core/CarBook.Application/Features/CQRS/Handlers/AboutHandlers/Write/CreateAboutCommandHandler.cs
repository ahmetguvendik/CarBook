using System;
using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write
{
	public class CreateAboutCommandHandler
	{
		private readonly IRepository<About> _repository;
		public CreateAboutCommandHandler(IRepository<About> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateAboutCommand createAboutCommand)
		{
			var about = new About();
			about.Id = Guid.NewGuid().ToString();
			about.Description = createAboutCommand.Description;
			about.ImageURL = createAboutCommand.ImageURL;
			about.Title = createAboutCommand.Title;
            await _repository.CreateAsync(about);
		}
	}
}

