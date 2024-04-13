using System;
namespace CarBook.Domain.Entities
{
	public class Brand : BaseEntity
	{
		public string Name { get; set; }
		public List<Car> Cars { get; set; }
	}
}

