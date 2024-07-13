using System;
namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
	public class GetBlogWIthCommentsByBlogIdQueryResult
	{
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Description { get; set; }
        public string BlogId { get; set; }
    }
}

