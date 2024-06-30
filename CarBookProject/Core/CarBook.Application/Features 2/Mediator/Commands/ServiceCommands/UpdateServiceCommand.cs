using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands
{
	public class UpdateServiceCommand : IRequest
	{
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconURL { get; set; }
    }
}

