using System;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Read
{
	public class GetCategoryQueryHandler
	{
		private readonly IRepository<Category> _repository;

        public GetCategoryQueryHandler(IRepository<Category> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCategoryQueryResult>> Handle()
		{
			var category = await _repository.GetAllAsync();
            return category.Select(x => new GetCategoryQueryResult
            {
				Id = x.Id,
                Name = x.Name
            }).ToList();
        }
	}
}

