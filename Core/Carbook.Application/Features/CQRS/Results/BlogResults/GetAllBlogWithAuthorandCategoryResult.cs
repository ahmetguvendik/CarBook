namespace CarBook.Application.Features.Mediator.Results.BlogResults;

public class GetAllBlogWithAuthorandCategoryResult
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedTime { get; set; }
    public string AuthorName { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }

}