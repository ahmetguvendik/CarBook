using System;
namespace CarBook.Domain.Entities
{
	public class Car : BaseEntity
	{
		public string Model { get; set; }
		public string CoverImageUrl { get; set; }
		public int Km { get; set; }
		public string Vites { get; set; }
		public int Koltuk { get; set; }
		public int Bagaj { get; set; }
		public string Fuel { get; set; }
		public string DetailImageUrl { get; set; }
		public Brand Brand { get; set; }
		public string BrandId { get; set; }
        public List<CarFeatures> CarFeatures { get; set; }
		public List<CarDescription> CarDescriptions { get; set; }
        public List<CarPricing> CarPricings { get; set; }
    }
}

