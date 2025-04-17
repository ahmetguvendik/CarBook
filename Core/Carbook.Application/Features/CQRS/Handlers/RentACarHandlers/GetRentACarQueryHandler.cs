using Carbook.Application.Features.CQRS.Queries.RentACarQueries;
using Carbook.Application.Features.CQRS.Results.RentACarResults;
using Carbook.Application.Repositories.RentACarRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.RentACarHandlers;

public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
{
    private readonly IRentACarRepository _repository;

    public GetRentACarQueryHandler(IRentACarRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationID && x.Available == true);
        return values.Select(x => new GetRentACarQueryResult
        {
            CarId = x.CarId,
             
        }).ToList();
    }
} 