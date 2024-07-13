using System;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.TestimonialQueries
{
	public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdQueryResult>
	{
        public string Id { get; set; }

        public GetTestimonialByIdQuery(string id)
        {
            Id = id;
        }
    }
}

