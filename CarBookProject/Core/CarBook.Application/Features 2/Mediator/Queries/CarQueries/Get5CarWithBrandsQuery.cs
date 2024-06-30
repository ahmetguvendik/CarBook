using System;
using CarBook.Application.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarQueries
{
	public class Get5CarWithBrandsQuery : IRequest<List<Get5CarWithBrandsQueryResult>>
    {
		public Get5CarWithBrandsQuery()
		{
		}
	}
}

