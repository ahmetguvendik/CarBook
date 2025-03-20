namespace Carbook.Application.Features.CQRS.Results.AboutResults;

public class GetAboutByIdQueryResult
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageURL { get; set; }
}