using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
	public class RemoveTestimonialCommand : IRequest
	{
		public string Id { get; set; }
		public RemoveTestimonialCommand(string id)
		{
			Id = id;
		}
	}
}

