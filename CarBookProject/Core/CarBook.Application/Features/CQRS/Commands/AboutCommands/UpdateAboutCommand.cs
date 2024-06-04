using System;
namespace CarBook.Application.Features.CQRS.Commands.AboutCommands
{
	public class UpdateAboutCommand
	{
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}

