using System;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Write
{
	public class UpdateCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateCategoryCommand command)
		{
			var category = await _repository.GetByIdAsync(command.Id);
			category.Name = command.Name;
			await _repository.UpdateAsync(category);
		}
	}
}

