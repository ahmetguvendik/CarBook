using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using Carbook.Application.Repositories.StatisticsRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetAvgRentPriceForWeeklyQueryHandler : IRequestHandler<GetAvgRentPriceForWeeklyQuery, GetAvgRentPriceForWeeklyQueryResult>
{
    private readonly IStatisticsRepository  _statisticsRepository;

    public GetAvgRentPriceForWeeklyQueryHandler(IStatisticsRepository statisticsRepository)
    {
         _statisticsRepository = statisticsRepository;
    }
    public async Task<GetAvgRentPriceForWeeklyQueryResult> Handle(GetAvgRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticsRepository.GetAvgRentPriceForWeekly();
        return new GetAvgRentPriceForWeeklyQueryResult()
        {
            AvgPriceForWeekly = value
        };
    }
}