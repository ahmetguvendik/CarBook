using System;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Repositories.BlogRepository;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read
{
	public class GetBlogWithAuthorByBlogIdQueryHandler : IRequestHandler<GetBlogWithAuthorByBlogIdQuery,List<GetBlogWithAuthorByBlogIdResult>>
	{
        private readonly IBlogRepository _blogRepository;
		public GetBlogWithAuthorByBlogIdQueryHandler(IBlogRepository blogRepository)
		{
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogWithAuthorByBlogIdResult>> Handle(GetBlogWithAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await _blogRepository.GetBlogWithAuthorByBlogId(request.Id);
            return blog.Select(x => new GetBlogWithAuthorByBlogIdResult
            {
                AuthorDescription = x.Author.Description,
                AuthorId = x.Author.Id,
                AuthorImageUrl = x.Author.ImageUrl,
                AuthorName = x.Author.Name,
                BlogId = x.Id,
                Id = x.Id,
            }).ToList();
        }
    }
}

