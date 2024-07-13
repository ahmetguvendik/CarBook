using System;
using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
	public class UpdateTestimonialCommand : IRequest
	{
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageURL { get; set; }
    }
}

