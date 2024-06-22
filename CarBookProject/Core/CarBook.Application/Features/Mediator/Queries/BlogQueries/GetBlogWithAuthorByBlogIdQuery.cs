using System;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
	public class GetBlogWithAuthorByBlogIdQuery : IRequest<List<GetBlogWithAuthorByBlogIdResult>>
	{
		public string Id { get; set; }

		public GetBlogWithAuthorByBlogIdQuery(string id)
		{
			Id = id;
		}
	}
}

