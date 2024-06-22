using System;
namespace CarBook.Dto.BlogDTOs
{
	public class ResumeGetBlogWithAuthorByIdDto
	{
        public string Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
        public string AuthorId { get; set; }
    }
}

