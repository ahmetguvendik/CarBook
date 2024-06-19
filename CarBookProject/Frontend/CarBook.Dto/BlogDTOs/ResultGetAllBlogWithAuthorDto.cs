using System;
namespace CarBook.Dto.BlogDTOs
{
	public class ResultGetAllBlogWithAuthorDto
	{
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}

