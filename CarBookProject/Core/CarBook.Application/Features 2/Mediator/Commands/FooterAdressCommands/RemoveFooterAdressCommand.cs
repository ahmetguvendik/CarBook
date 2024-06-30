using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FooterAdressCommands
{
	public class RemoveFooterAdressCommand : IRequest
    {
		public string Id { get; set; }
		public RemoveFooterAdressCommand(string id)
		{
			Id = id;
		}
	}
}

