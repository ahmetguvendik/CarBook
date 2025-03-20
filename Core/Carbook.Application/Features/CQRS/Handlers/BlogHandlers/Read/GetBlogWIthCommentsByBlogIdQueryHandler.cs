using System;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Repositories.BlogRepository;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
	public class GetBlogWIthCommentsByBlogIdQueryHandler : IRequestHandler<GetBlogWIthCommentsByBlogIdQuery, List<GetBlogWIthCommentsByBlogIdQueryResult>>
	{
        private readonly IBlogRepository _blogRepository;
		public GetBlogWIthCommentsByBlogIdQueryHandler(IBlogRepository blogRepository)
		{
            _blogRepository = blogRepository;
		}

        public Task<List<GetBlogWIthCommentsByBlogIdQueryResult>> Handle(GetBlogWIthCommentsByBlogIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

