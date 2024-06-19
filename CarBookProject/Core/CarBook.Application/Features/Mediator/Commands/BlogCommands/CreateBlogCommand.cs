using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands
{
	public class CreateBlogCommand : IRequest
	{
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public string AuthorId { get; set; }
        public string CategoryId { get; set; }
    }
}

