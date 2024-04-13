using System;
namespace CarBook.Domain.Entities
{
	public class CarFeatures : BaseEntity
	{
		public Car Car { get; set; }
		public string CarId { get; set; }
		public Features Features { get; set; }
		public string FeaturesId { get; set; }
		public bool IsAvaible { get; set; }	
	}
}

