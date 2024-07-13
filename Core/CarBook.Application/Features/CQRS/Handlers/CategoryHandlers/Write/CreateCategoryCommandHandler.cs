using System;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Write
{
	public class CreateCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;
		public CreateCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCategoryCommand command)
		{
			var category = new Category();
			category.Id = Guid.NewGuid().ToString();
			category.Name = command.Name;
			await _repository.CreateAsync(category);
		}
	}
}

