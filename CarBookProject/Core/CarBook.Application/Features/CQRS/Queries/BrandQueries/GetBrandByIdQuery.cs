using System;
namespace CarBook.Application.Features.CQRS.Queries.BrandQueries
{
	public class GetBrandByIdQuery
	{
		public string id { get; set; }

		public GetBrandByIdQuery(string Id)
		{
			id = Id;
		}
	}
}

