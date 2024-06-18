using System;
namespace CarBook.Application.Features.Mediator.Results.CarResults
{
	public class GetCarQueryResult
	{
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Vites { get; set; }
        public int Koltuk { get; set; }
        public int Bagaj { get; set; }
        public string Fuel { get; set; }
        public string DetailImageUrl { get; set; }
        public string BrandId { get; set; }
    }
}

