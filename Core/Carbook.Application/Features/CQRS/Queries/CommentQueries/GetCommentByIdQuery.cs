using System;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
	public class GetCommentByIdQuery : IRequest<GetCommentByIdQueryResult>
	{
		public string Id { get; set; }

		public GetCommentByIdQuery(string id)
		{
			Id = id;
		}
	}
}

