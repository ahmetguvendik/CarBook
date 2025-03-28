using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using Carbook.Application.Repositories.StatisticsRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetCarCountByFuelElectricQuerHandler : IRequestHandler<GetCarCountByFuelElectricQuery,GetCarCountByFuelElectricQueryResult>
{
    private readonly IStatisticsRepository  _statisticsRepository;

    public GetCarCountByFuelElectricQuerHandler(IStatisticsRepository statisticsRepository)
    {
         _statisticsRepository = statisticsRepository;
    }
    public async Task<GetCarCountByFuelElectricQueryResult> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticsRepository.GetCarCountByFuelElectric();
        return new GetCarCountByFuelElectricQueryResult()
        {
            FuelEletricCount = value,
        };
    }
}