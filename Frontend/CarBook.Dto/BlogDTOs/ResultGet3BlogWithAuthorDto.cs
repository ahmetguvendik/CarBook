using System;
namespace CarBook.Dto.BlogDTOs
{
	public class ResultGet3BlogWithAuthorDto
	{
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public string AuthorName { get; set; }
        public string CategoryId { get; set; }
    }
}

