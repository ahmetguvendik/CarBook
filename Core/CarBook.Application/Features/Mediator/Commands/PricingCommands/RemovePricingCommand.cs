using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommands
{
	public class RemovePricingCommand: IRequest
	{
		public string Id { get; set; }
		public RemovePricingCommand(string id)
		{
			Id = id;
		}
	}
}

