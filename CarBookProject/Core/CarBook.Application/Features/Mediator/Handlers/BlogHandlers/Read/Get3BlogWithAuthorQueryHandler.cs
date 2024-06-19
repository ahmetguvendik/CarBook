using System;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Repositories.BlogRepository;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
	public class Get3BlogWithAuthorQueryHandler : IRequestHandler<Get3BlogWithAuthorQuery,List<Get3BlogWithAuthorQueryResult>>
	{
        private readonly IBlogRepository _blogRepository;
		public Get3BlogWithAuthorQueryHandler(IBlogRepository blogRepository)
		{
            _blogRepository = blogRepository;
		}

        public async Task<List<Get3BlogWithAuthorQueryResult>> Handle(Get3BlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var blogwithAuthor = await _blogRepository.Get3BlogWithAuthor();
            return blogwithAuthor.Select(x => new Get3BlogWithAuthorQueryResult
            {
                AuthorName = x.Author.Name,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedTime = x.CreatedTime,
                Title = x.Title
            }).ToList();
        }
    }
}

