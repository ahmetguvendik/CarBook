using System;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
	public class GetBlogWIthCommentsByBlogIdQuery : IRequest<List<GetBlogWIthCommentsByBlogIdQueryResult>>
    {
		public string Id { get; set; }

		public GetBlogWIthCommentsByBlogIdQuery(string id)
		{
			Id = id;
		}
	}
}

