using Carbook.Application.Features.CQRS.Queries.LocationQueries;
using Carbook.Application.Features.CQRS.Results.LocationResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.LocationHandlers.Read;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery,GetLocationByIdQueryResult>
{
    private readonly IRepository<Location> _repository;

    public GetLocationByIdQueryHandler( IRepository<Location> repository)
    {
         _repository = repository;
    }
    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
         var value = await _repository.GetByIdAsync(request.Id);
         return new GetLocationByIdQueryResult()
         {
             Id = value.Id,
             Name = value.Name,
         };
    }
}