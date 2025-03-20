using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.PricingCommands
{
	public class UpdatePricingCommand : IRequest
	{
		public string Id { get; set; }
		public string Name { get; set; }	
	}
}

