using System;
using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write
{
	public class UpdateBannerCommandHandler
	{
		private readonly IRepository<Banner> _repository;
		public UpdateBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBannerCommand command)
		{
			var banner = await _repository.GetByIdAsync(command.id);
			banner.Description = command.Description;
			banner.Title = command.Title;
			banner.VideoDescription = command.VideoDescription;
			banner.VideoURL = command.VideoURL;
			await _repository.UpdateAsync(banner);
		}
	}
}

