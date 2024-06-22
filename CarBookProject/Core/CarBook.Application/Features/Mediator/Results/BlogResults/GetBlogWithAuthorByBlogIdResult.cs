using System;
namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
	public class GetBlogWithAuthorByBlogIdResult
	{
        public string Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }
        public string AuthorId { get; set; }
        public string BlogId { get; set; }
    }
}

