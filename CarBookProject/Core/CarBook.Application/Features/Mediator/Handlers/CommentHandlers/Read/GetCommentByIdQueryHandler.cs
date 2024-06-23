using System;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Repositories.GenericRepository;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Read
{
	public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery,GetCommentByIdQueryResult>
	{
        private readonly ICommentRepository _commentRepository;
		public GetCommentByIdQueryHandler(ICommentRepository commentRepository)
		{
            _commentRepository = commentRepository;
		}

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _commentRepository.GetByIdAsync(request.Id);
            return new GetCommentByIdQueryResult
            {
                BlogId = value.BlogId,
                CreatedTime = value.CreatedTime,
                Description = value.Description,
                Name = value.Name
            };
        }
    }
}

