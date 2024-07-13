using System;
namespace CarBook.Application.Features.CQRS.Commands.ContactCommands
{
	public class CreateContactCommand
	{
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}

