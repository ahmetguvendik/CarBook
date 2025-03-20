using Carbook.Application.Features.CQRS.Queries.ServiceQueries;
using Carbook.Application.Features.CQRS.Results.ServiceResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ServiceHandlers.Read;

public class GetSeviceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery,GetServiceByIdQueryResult>
{
    private readonly IRepository<Service> _serviceRepository;

    public GetSeviceByIdQueryHandler(IRepository<Service> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
       var value = await _serviceRepository.GetByIdAsync(request.Id);
       return new GetServiceByIdQueryResult
       {
           Description = value.Description,
           IconURL = value.IconURL,
           Title = value.Title
       };
        
    }
}