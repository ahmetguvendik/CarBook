using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using CarBook.Application.Repositories.CarRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResult>
{
    private readonly ICarRepository  _carRepository;

    public GetCarCountQueryHandler(ICarRepository carRepository)
    {
         _carRepository = carRepository;
    }
    
    public async Task<GetCarCountQueryResult> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
    {
        var value = _carRepository.CarCount();
        return new GetCarCountQueryResult()
        {
             CarCount = value
        };
    }
}