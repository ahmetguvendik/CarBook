using System;
namespace CarBook.Domain.Entities
{
	public class CarPricing : BaseEntity
	{
		public Car Car { get; set; }
		public string CarId { get; set; }
		public Pricing Pricing { get; set; }
		public string PricingId { get; set; }
		public string Price { get; set; }
	}
}

