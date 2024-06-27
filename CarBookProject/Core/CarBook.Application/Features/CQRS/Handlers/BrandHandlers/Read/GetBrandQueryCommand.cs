using System;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Read
{
	public class GetBrandQueryCommand
	{
		private readonly IRepository<Brand> _repository;
		public GetBrandQueryCommand(IRepository<Brand> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBrandQueryResult>> Handle()
		{
			var brand = await _repository.GetAllAsync();
			return brand.Select(x => new GetBrandQueryResult
			{
				Id = x.Id,
				Name = x.Name
			}).ToList();
		}
	}
}

