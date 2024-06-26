﻿using System;
using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Write
{
	public class RemoveCategoryCommandHandler
	{
		private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveCategoryCommand command)
		{
			var category = await _repository.GetByIdAsync(command.Id);
			await _repository.RemoveAsync(category);

		}
	}
}

