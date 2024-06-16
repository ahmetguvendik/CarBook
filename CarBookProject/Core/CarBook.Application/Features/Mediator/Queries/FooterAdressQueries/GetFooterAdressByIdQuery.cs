using System;
using CarBook.Application.Features.Mediator.Results.FooterAdressResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.FooterAdressQueries
{
	public class GetFooterAdressByIdQuery : IRequest<GetFooterAdressByIdQueryResult>
	{

		public string Id { get; set; }

		public GetFooterAdressByIdQuery(string id)
		{
			Id = id;
		}
	}
}

