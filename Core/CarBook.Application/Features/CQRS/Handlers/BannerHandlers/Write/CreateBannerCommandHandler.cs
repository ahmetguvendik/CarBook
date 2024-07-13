using System;
using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write
{
	public class CreateBannerCommandHandler
	{
		private readonly IRepository<Banner> _repository;
		public CreateBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateBannerCommand command)
		{
			var banner = new Banner();
			banner.Id = Guid.NewGuid().ToString();
			banner.Title = command.Title;
			banner.Description = command.Description;
			banner.VideoURL = command.VideoURL;
			banner.VideoDescription = command.VideoDescription;
			await _repository.CreateAsync(banner);

		}
	}
}

