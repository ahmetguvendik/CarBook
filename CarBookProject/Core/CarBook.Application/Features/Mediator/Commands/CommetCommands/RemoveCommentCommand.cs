using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CommetCommands
{
	public class RemoveCommentCommand : IRequest
	{
		public string Id { get; set; }

		public RemoveCommentCommand(string id)
		{
			Id = id;
		}
	}
}

