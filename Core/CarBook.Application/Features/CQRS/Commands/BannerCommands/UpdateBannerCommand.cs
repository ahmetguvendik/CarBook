using System;
namespace CarBook.Application.Features.CQRS.Commands.BannerCommands
{
	public class UpdateBannerCommand
	{
        public string id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoURL { get; set; }
    }
}

