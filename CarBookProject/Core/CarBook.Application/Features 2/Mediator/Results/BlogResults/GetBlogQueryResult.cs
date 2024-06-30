using System;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
	public class GetBlogQueryResult
	{
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public string AuthorId { get; set; }
        public string CategoryId { get; set; }
    }
}

