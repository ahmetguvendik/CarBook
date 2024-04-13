using System;
namespace CarBook.Domain.Entities
{
	public class Contact : BaseEntity
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Description { get; set; }
		public DateTime DateTime { get; set; }
	}
}

