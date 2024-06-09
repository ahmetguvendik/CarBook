using System;
namespace CarBook.Application.Features.CQRS.Commands.BannerCommands
{
	public class RemoveBannerCommand
	{
        public string id { get; set; }

        public RemoveBannerCommand(string _id)
        {
            id = _id;
        }

    }
}

