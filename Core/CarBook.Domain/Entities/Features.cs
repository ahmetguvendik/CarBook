using System;
namespace CarBook.Domain.Entities
{
	public class Features : BaseEntity
	{
		public string Name { get; set; }
		public List<CarFeatures> CarFeatures { get; set; }
	}
}

