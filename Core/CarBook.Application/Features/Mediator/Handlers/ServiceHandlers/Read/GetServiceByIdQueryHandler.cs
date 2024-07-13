using System;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers.Read
{
	public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                Description = value.Description,
                IconURL = value.IconURL,
                Title = value.Title
            };
        }
    }
}

