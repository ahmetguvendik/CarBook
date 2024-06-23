using System;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Repositories.GenericRepository;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Read
{
	public class GetCommentsWithBlogIdQueryHandler : IRequestHandler<GetCommentsWithBlogIdQuery, List<GetCommentsWithBlogIdResult>>
	{
        private readonly ICommentRepository _commentRepository;
		public GetCommentsWithBlogIdQueryHandler(ICommentRepository commentRepository)
		{
            _commentRepository = commentRepository;
		}

        public async Task<List<GetCommentsWithBlogIdResult>> Handle(GetCommentsWithBlogIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _commentRepository.GetCommentsWithBlogId(request.BlogId);
            return value.Select(x => new GetCommentsWithBlogIdResult
            {
                BlogId = x.BlogId,
                CreatedTime = x.CreatedTime,
                Description = x.Description,
                Name = x.Name

            }).ToList();
        }
    }
}

