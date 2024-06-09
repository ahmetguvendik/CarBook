using System;
namespace CarBook.Application.Features.CQRS.Queries.AboutQueries
{
	public class GetAboutByIdQuery
	{
		public string Id { get; set; }

		public GetAboutByIdQuery(string id)
		{
			Id = id;
		}
	}
}

