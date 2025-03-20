using Carbook.Application.Features.CQRS.Queries.LocationQueries;
using Carbook.Application.Features.CQRS.Results.LocationResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.LocationHandlers.Read;

public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery,List<GetLocationQueryResult>>
{
    private readonly IRepository<Location> _repository;

    public GetLocationQueryHandler( IRepository<Location> repository)
    {
         _repository = repository;
    }
    public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetLocationQueryResult
        {
            Name = x.Name,
            Id = x.Id
        }).ToList();
    }
}