using System;
namespace CarBook.Application.Features.CQRS.Commands.BrandCommands
{
	public class RemoveBrandCommand
	{
        public string id { get; set; }

        public RemoveBrandCommand(string Id)
        {
            id = Id;
        }
    }
}

