using System;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Write
{
	public class RemoveBrandCommandHandler
	{
		private readonly IRepository<Brand> _repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveBrandCommand command)
		{
			var brand = await _repository.GetByIdAsync(command.id);
			await _repository.RemoveAsync(brand);
		}
	}
}

