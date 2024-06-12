using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.FeatureCommands
{
	public class UpdateFeatureCommand : IRequest
	{
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

