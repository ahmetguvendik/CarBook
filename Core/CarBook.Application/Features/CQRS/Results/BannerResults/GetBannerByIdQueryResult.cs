using System;
namespace CarBook.Application.Features.CQRS.Results.BannerResults
{
	public class GetBannerByIdQueryResult
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoURL { get; set; }
    }
}

