using System;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.Read
{
	public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery,List<GetPricingQueryResult>>
	{
        private readonly IRepository<CarBook.Domain.Entities.Pricing> _repository;
        public GetPricingQueryHandler(IRepository<CarBook.Domain.Entities.Pricing> repository)
        {
            _repository = repository;
        }
  

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPricingQueryResult
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

        }
    }
}

