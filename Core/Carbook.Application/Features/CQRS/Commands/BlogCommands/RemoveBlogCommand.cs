using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BlogCommands
{
	public class RemoveBlogCommand : IRequest
	{
		public string Id { get; set; }
		public RemoveBlogCommand(string id)
		{
			Id = id;
		}
	}
}

