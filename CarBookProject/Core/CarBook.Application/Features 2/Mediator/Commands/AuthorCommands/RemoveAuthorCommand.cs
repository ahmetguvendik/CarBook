using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AuthorCommands
{
	public class RemoveAuthorCommand : IRequest
	{
		public string Id { get; set; }
		public RemoveAuthorCommand(string id)
		{
			Id = id;
		}
	}
}

