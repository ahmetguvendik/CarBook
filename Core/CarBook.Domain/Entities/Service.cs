using System;
namespace CarBook.Domain.Entities
{ 
	public class Service : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string IconURL { get; set; }
	}
}

