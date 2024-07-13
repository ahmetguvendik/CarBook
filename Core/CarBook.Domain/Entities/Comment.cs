using System;
namespace CarBook.Domain.Entities
{
	public class Comment : BaseEntity
	{
		public string Name { get; set; }
		public DateTime CreatedTime { get; set; }
		public string Description { get; set; }
		public string BlogId { get; set; }
		public Blog Blog { get; set; }
	}
}

