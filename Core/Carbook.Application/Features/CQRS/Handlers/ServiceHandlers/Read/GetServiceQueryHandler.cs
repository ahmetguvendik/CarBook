using Carbook.Application.Features.CQRS.Queries.ServiceQueries;
using Carbook.Application.Features.CQRS.Results.ServiceResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ServiceHandlers.Read;

public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery,List<GetServiceQueryResult>>
{
    private readonly IRepository<Service> _serviceRepository;

    public GetServiceQueryHandler(IRepository<Service> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    
    public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var value = await _serviceRepository.GetAllAsync();
        return value.Select(x => new GetServiceQueryResult
        {
            
            Id=x.Id,
            Description = x.Description,
            IconURL = x.IconURL,
            Title = x.Title
        }).ToList();
    }
}