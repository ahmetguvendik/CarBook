using System;
using CarBook.Application.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarQueries
{
	public class GetCarWithBrandsQuery : IRequest<List<GetCarWithBrandsQueryResult>>
    {
		
	}
}

