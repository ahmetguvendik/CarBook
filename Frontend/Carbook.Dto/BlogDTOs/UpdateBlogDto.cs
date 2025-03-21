namespace CarBook.Dto.BlogDTOs;

public class UpdateBlogDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string CoverImageUrl { get; set; }
    public DateTime CreatedTime { get; set; }
    public string AuthorId { get; set; }
    public string CategoryId { get; set; }
    public string Description { get; set; } 
}