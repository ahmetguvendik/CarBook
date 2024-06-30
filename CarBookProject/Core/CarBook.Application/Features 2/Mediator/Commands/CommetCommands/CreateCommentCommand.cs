using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommetCommands
{
	public class CreateCommentCommand : IRequest
	{
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Description { get; set; }
        public string BlogId { get; set; }
    }
}

