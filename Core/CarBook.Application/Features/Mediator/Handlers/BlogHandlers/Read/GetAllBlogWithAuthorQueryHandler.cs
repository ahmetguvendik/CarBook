using System;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Repositories.BlogRepository;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
	public class GetAllBlogWithAuthorQueryHandler : IRequestHandler<GetAllBlogWithAuthorQuery,List<GetAllBlogWithAuthorQueryResult>>
	{
        private readonly IBlogRepository _blogRepository;
		public GetAllBlogWithAuthorQueryHandler(IBlogRepository blogRepository)
		{
            _blogRepository = blogRepository;
		}

        public async Task<List<GetAllBlogWithAuthorQueryResult>> Handle(GetAllBlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogWithAuthor();
            return blogs.Select(x => new GetAllBlogWithAuthorQueryResult
            {
                Id = x.Id,
                AuthorName = x.Author.Name,
                Description = x.Description,
                CategoryId = x.CategoryId,
                CoverImageUrl = x.CoverImageUrl,
                CreatedTime = x.CreatedTime,
                Title = x.Title
            }).ToList();
        }
    }
}

