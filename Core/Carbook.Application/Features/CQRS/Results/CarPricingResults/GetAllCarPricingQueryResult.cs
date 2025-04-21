namespace CarBook.Application.Features.Mediator.Results.CarPricingResults;

public class GetAllCarPricingQueryResult
{
    public string Id { get; set; }
    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
    public string BrandName { get; set; }
    public string PriceName { get; set; }   
    public decimal Price { get; set; }
}