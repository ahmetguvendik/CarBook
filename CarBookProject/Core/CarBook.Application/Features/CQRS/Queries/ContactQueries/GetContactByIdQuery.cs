using System;
namespace CarBook.Application.Features.CQRS.Queries.ContactQueries
{
	public class GetContactByIdQuery
	{
        public string Id { get; set; }

        public GetContactByIdQuery(string id)
        {
            Id = id;
        }

    }
}

