using System;
namespace CarBook.Dto.CarPricingDTOs
{
	public class GetCarPricingWithCarDto
	{
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string BrandName { get; set; }
        public string Price { get; set; }
    }
}

