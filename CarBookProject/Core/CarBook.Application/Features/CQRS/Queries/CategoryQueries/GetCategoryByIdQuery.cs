﻿using System;
namespace CarBook.Application.Features.CQRS.Queries.CategoryQueries
{
	public class GetCategoryByIdQuery
	{
		public string Id { get; set; }

		public GetCategoryByIdQuery(string id)
		{
			Id = id;
		}
	}
}

