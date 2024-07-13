using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ServiceCommands
{
	public class RemoveServiceCommand : IRequest
	{
		public string Id { get; set; }

		public RemoveServiceCommand(string id)
		{
			Id = id;
		}
	}
}

