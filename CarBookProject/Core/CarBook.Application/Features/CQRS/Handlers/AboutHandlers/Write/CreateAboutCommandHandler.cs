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
			await _repository.CreateAsync(new About
			{
				Id = Guid.NewGuid().ToString(),
				Description = createAboutCommand.Description,
				ImageURL = createAboutCommand.ImageURL,
				Title = createAboutCommand.Title
			});
		}
	}
}

