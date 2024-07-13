using System;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers.Write
{
    public class CreataTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
	{
        private readonly IRepository<Testimonial> _repository;
        public CreataTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = new Testimonial();
            testimonial.Id = Guid.NewGuid().ToString();
            testimonial.Name = request.Name;
            testimonial.Title = request.Title;
            testimonial.ImageURL = request.ImageURL;
            testimonial.Comment = request.Comment;
            await _repository.CreateAsync(testimonial);

        }
    }
}

