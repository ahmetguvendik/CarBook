using System;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands
{
	public class UpdateBlogCommand : IRequest
	{
        public string Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedTime { get; set; }
        public Author Author { get; set; }
        public string AuthorId { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }
    }
}

