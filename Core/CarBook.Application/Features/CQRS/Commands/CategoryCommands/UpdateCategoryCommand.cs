using System;
namespace CarBook.Application.Features.CQRS.Commands.CategoryCommands
{
	public class UpdateCategoryCommand
	{
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

