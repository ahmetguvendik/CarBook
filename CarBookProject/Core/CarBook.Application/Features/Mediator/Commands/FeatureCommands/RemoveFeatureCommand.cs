using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommands
{
	public class RemoveFeatureCommand : IRequest
	{

		public string Id { get; set; }

		public RemoveFeatureCommand(string id)
		{
			Id = id;
		}


	}
}

