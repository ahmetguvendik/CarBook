using System;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
	public class GetCommentsWithBlogIdQuery : IRequest<List<GetCommentsWithBlogIdResult>>
	{
        public string BlogId { get; set; }

        public GetCommentsWithBlogIdQuery(string id)
        {
            BlogId = id;
        }
    }
}

