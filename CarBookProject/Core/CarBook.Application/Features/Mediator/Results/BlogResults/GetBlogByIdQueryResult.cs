﻿using System;
namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
	public class GetBlogByIdQueryResult
	{
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public string AuthorId { get; set; }
        public string CategoryId { get; set; }
    }
}
