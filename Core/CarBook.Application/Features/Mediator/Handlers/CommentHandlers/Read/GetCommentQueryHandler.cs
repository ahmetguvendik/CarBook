using System;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Repositories.GenericRepository;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Read
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery,List<GetCommentQueryResult>>
	{
        private readonly ICommentRepository _commentRepository;
        public GetCommentQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var value = await _commentRepository.GetAllAsync();
            return value.Select(x => new GetCommentQueryResult
            {
                BlogId = x.BlogId,
                CreatedTime = x.CreatedTime,
                Description = x.Description,
                Name = x.Name
            }).ToList();
        }
    }
}

