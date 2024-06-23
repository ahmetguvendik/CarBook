using System;
namespace CarBook.Domain.Entities
{
	public class Blog : BaseEntity
	{
		public string Title { get; set; }
		public string CoverImageUrl { get; set; }
		public DateTime CreatedTime { get; set; }
		public Author Author { get; set; }
		public string AuthorId { get; set; }
		public Category Category { get; set; }
		public string CategoryId { get; set; }
		public string Description { get; set; }
		public List<Comment> Comments { get; set; }	
	}
}

