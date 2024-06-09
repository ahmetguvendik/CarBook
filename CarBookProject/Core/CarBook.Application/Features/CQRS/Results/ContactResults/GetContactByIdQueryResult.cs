using System;
namespace CarBook.Application.Features.CQRS.Results.ContactResults
{
	public class GetContactByIdQueryResult
	{
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}

