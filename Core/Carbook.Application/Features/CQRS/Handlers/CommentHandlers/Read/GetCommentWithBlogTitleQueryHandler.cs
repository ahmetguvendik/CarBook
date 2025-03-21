using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Repositories.GenericRepository;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Read;

public class GetCommentWithBlogTitleQueryHandler: IRequestHandler<GetCommentWithBlogTitleQuery, List<GetCommentWithBlogTitleResult>>
{
    private readonly ICommentRepository _commentRepository;
    public GetCommentWithBlogTitleQueryHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
    
    public async Task<List<GetCommentWithBlogTitleResult>> Handle(GetCommentWithBlogTitleQuery request, CancellationToken cancellationToken)
    {
        var value = await _commentRepository.GetAllCommentsWithBlogTitle();
        return value.Select(x => new GetCommentWithBlogTitleResult
        {
            Id = x.Id,
            BlogTitle = x.Blog.Title,
            CreatedTime = x.CreatedTime,
            Description = x.Description,
            Name = x.Name
        }).ToList();
    }
}