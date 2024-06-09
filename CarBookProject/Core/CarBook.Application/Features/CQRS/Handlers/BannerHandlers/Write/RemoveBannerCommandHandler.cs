using System;
using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write
{
	public class RemoveBannerCommandHandler
	{
		private readonly IRepository<Banner> _repository;
		public RemoveBannerCommandHandler(IRepository<Banner> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveBannerCommand command)
		{
			var banner =  await _repository.GetByIdAsync(command.id);
			await _repository.RemoveAsync(banner);
		}
	}

}

