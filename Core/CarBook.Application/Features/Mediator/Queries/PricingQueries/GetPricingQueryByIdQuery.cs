using System;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries
{
	public class GetPricingQueryByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
		public string Id { get; set; }
		public GetPricingQueryByIdQuery(string id)
		{
			Id = id;
		}
	}
}

