using System;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Read
{
	public class GetCategoryByIdQueryHandler
	{
		private readonly IRepository<Category> _repository;
		public GetCategoryByIdQueryHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
		{
			var category = await _repository.GetByIdAsync(query.Id);
			return new GetCategoryByIdQueryResult()
			{
				Name = category.Name
			};
		}
	}
}

