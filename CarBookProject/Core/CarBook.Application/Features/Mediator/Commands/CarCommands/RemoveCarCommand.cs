using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarCommands
{
	public class RemoveCarCommand : IRequest
	{
        public string Id { get; set; }

        public RemoveCarCommand(string id)
        {
            Id = id;
        }
    }
}

