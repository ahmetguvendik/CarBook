using System;
namespace CarBook.Domain.Entities
{
	public class CarDescription : BaseEntity
	{
		public string Details { get; set; }
		public Car Car { get; set; }
		public string CarId { get; set; }
	}
}

