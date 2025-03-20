using System;
using CarBook.Application.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarQueries
{
	public class GetCarByIdQuery : IRequest<GetCarByIdQueryResult>
    {
        public string Id { get; set; }

        public GetCarByIdQuery(string id)
        {
            Id = id;
        }
    }
}

