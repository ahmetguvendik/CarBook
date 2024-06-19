using System;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarPricingQueries
{
	public class GetCarPricingQuery : IRequest<List<GetCarPricingQueryResult>>
	{
		public GetCarPricingQuery()
		{
		}
	}
}

