using System;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using Carbook.Application.Repositories;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers.Read
{
	public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery,List<GetTestimonialQueryResult>>
	{
        private readonly IRepository<Testimonial> _repository;
		public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
		{
            _repository = repository;
		}

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult
            {
                Id = x.Id,
                Comment = x.Comment,
                ImageURL = x.ImageURL,
                Name = x.Name,
                Title = x.Title
            }).ToList();
        }
    }
}

