using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using Carbook.Application.Repositories.StatisticsRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetAvgRentPriceForDailyQueryHandler : IRequestHandler<GetAvgRentPriceForDailyQuery, GetAvgRentPriceForDailyQueryResult>
{
    private readonly IStatisticsRepository  _statisticsRepository;

    public GetAvgRentPriceForDailyQueryHandler(IStatisticsRepository statisticsRepository)
    {
         _statisticsRepository = statisticsRepository;
    }
    public async Task<GetAvgRentPriceForDailyQueryResult> Handle(GetAvgRentPriceForDailyQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticsRepository.GetAvgRentPriceForDaily();
        return new GetAvgRentPriceForDailyQueryResult()
        {
            AvgPriceForDaily = value
        };
    }
}