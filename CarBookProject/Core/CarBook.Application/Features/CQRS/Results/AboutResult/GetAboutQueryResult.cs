using System;
namespace CarBook.Application.Features.CQRS.Results.AboutResult
{
	public class GetAboutQueryResult
	{
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}

