using System;
using CarBook.Application.Features.Mediator.Results.AuthorResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.AuthorQueries
{
	public class GetAuthorByIdQuery : IRequest<GetAuthorByIdQueryResult>
	{
		public string Id { get; set; }
		public GetAuthorByIdQuery(string id)
		{
			Id = id;
		}
	}
}

