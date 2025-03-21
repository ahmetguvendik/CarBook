using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Repositories.BlogRepository;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Read;

public class GetAllBlogWithAuthorandCategoryQueryHandler : IRequestHandler<GetAllBlogWithAuthorandCategoryQuery,List<GetAllBlogWithAuthorandCategoryResult>>
{
    private readonly IBlogRepository _blogRepository;
    public GetAllBlogWithAuthorandCategoryQueryHandler(IBlogRepository blogRepository)
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

    public async Task<List<GetAllBlogWithAuthorandCategoryResult>> Handle(GetAllBlogWithAuthorandCategoryQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _blogRepository.GetAllBlogWithAuthorandCategory();
        return blogs.Select(x => new GetAllBlogWithAuthorandCategoryResult
        {
            Id = x.Id,
            AuthorName = x.Author.Name,
            Description = x.Description,
            CreatedTime = x.CreatedTime,
            Title = x.Title,
            CoverImageUrl = x.CoverImageUrl,
            CategoryName = x.Category.Name,
            
        }).ToList();
    }
}

    
