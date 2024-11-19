using System;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.Read
{
	public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingQueryByIdQuery,GetPricingByIdQueryResult>
	{
        private readonly IRepository<Domain.Entities.Pricing> _repository;
		public GetPricingByIdQueryHandler(IRepository<Domain.Entities.Pricing> repository)
		{
            _repository = repository;
		}

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingQueryByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name
            };
        }
    }
}

