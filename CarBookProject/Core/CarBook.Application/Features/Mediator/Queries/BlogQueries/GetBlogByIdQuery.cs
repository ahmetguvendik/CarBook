using System;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
	public class GetBlogByIdQuery : IRequest<GetBlogByIdQueryResult>
	{
		public string Id { get; set; }
		public GetBlogByIdQuery(string id)
		{
			Id = id;
		}
	}
}

