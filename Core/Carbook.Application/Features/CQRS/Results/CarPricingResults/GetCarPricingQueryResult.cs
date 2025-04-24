using System;
namespace CarBook.Application.Features.Mediator.Results.CarPricingResults
{
	public class GetCarPricingQueryResult 
	{
		public string Id { get; set; }
		public string CarId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
    }	
}

