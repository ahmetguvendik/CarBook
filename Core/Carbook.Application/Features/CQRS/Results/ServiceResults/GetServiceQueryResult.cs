namespace Carbook.Application.Features.CQRS.Results.ServiceResults;

public class GetServiceQueryResult
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string IconURL { get; set; }
}