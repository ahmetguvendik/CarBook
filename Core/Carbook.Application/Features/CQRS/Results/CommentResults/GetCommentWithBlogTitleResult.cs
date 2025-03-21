namespace CarBook.Application.Features.Mediator.Results.CommentResults;

public class GetCommentWithBlogTitleResult
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedTime { get; set; }
    public string Description { get; set; }
    public string BlogTitle { get; set; }
}