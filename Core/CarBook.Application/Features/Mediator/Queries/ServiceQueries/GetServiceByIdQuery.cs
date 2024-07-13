using System;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.ServiceQueries
{
	public class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResult>
	{
        public string Id { get; set; }

        public GetServiceByIdQuery(string id)
        {
            Id = id;
        }
    }
}

