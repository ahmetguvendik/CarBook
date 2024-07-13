using System;
namespace CarBook.Application.Features.CQRS.Commands.BrandCommands
{
	public class UpdateBrandCommand
	{
        public string id { get; set; }
        public string Name { get; set; }
    }
}

