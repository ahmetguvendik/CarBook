using System;
using CarBook.Application.Features.Mediator.Results.FooterAdressResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAdressQueries
{
	public class GetFooterAdressQuery : IRequest<List<GetFooterAdressQueryResult>>
    {
		public GetFooterAdressQuery()
		{
		}
	}
}

