using System;
namespace CarBook.Domain.Entities
{
	public class About : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageURL { get; set; }
	}
}

