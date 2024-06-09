using System;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Read
{
	public class GetBrandByIdQueryHandler
	{
		private readonly IRepository<Brand> _repository;
        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
		{
			var brand = await _repository.GetByIdAsync(query.id);
			return new GetBrandByIdQueryResult()
			{
				Name = brand.Name
			};
		}
	}
}

