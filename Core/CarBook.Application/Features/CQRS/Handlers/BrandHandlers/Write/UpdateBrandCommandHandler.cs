using System;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Write
{
	public class UpdateBrandCommandHandler
	{
		private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBrandCommand command)
		{
			var brand = await _repository.GetByIdAsync(command.id);
			brand.Name = command.Name;
			await _repository.UpdateAsync(brand);
		}
	}
}

