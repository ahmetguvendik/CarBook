namespace CarBook.Dto.CarPricingDTOs;

public class CreateCarPricingDto
{
    public string CarId { get; set; }
    public string pricingId { get; set; }
    public decimal Price { get; set; }
}