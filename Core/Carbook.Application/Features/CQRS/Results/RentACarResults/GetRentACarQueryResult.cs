namespace Carbook.Application.Features.CQRS.Results.RentACarResults;

public class GetRentACarQueryResult
{
    public string CarId { get; set; }
    public string BrandName { get; set; }
    public string ModelName { get; set; }
    public string CoverImageUrl { get; set; }
} 