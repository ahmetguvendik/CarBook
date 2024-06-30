using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands
{
	public class UpdateAuthorCommand : IRequest
	{
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}

