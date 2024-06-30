using System;
using CarBook.Application.Features.Mediator.Results.FeatureResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FeatureQueries
{
	public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
    {
		public string Id { get; set; }

		public GetFeatureByIdQuery(string id)
		{
			Id = id;
		}
	}
}

