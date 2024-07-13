using System;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers.Read
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
	{
        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetServiceQueryResult
            {
                Id=x.Id,
                Description = x.Description,
                IconURL = x.IconURL,
                Title = x.Title
            }).ToList();
        }
    }
}

