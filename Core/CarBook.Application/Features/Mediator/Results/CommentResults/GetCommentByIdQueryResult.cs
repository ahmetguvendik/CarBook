using System;
namespace CarBook.Application.Features.Mediator.Results.CommentResults
{
	public class GetCommentByIdQueryResult
	{
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Description { get; set; }
        public string BlogId { get; set; }
    }
}

