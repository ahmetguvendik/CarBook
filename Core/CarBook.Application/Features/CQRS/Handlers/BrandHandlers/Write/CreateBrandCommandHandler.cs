using System;
using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Write
{
	public class CreateBrandCommandHandler
	{
		private readonly IRepository<Brand> _repository;
		public CreateBrandCommandHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateBrandCommand command)
		{
			var brand = new Brand();
			brand.Id = Guid.NewGuid().ToString();
			brand.Name = command.Name;
			await _repository.CreateAsync(brand);
		}
	}
}

