using System;
namespace CarBook.Application.Features.Mediator.Results.AuthorResults
{
	public class GetAuthorByIdQueryResult
	{
		public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}

