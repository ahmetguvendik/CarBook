namespace CarBook.Application.Features.Mediator.Results.CarResults;

public class GetCarWithPriceQueryResult
{
    public string CarID { get; set; }
    public string BrandID { get; set; }
    public string Model { get; set; }
    public string CoverImageUrl { get; set; }
    public int Km { get; set; }
    public string Vites { get; set; }
    public int Koltuk { get; set; }
    public int Bagaj { get; set; }
    public string Fuel { get; set; }
    public string DetailImageUrl { get; set; }
    public string BrandName { get; set; }
    public string PricingName { get; set; }
    public decimal PricingAmount { get; set; }
}