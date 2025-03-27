using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using Carbook.Application.Repositories.StatisticsRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetAvgRentPriceForMonthlyQueryHandler : IRequestHandler<GetAvgRentPriceForMonthlyQuery, GetAvgRentPriceForMonthlyQueryResult>
{
    private readonly IStatisticsRepository  _statisticsRepository;

    public GetAvgRentPriceForMonthlyQueryHandler(IStatisticsRepository statisticsRepository)
    {
         _statisticsRepository = statisticsRepository;
    }
    public async Task<GetAvgRentPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
    {
        var values = _statisticsRepository.GetAvgRentPriceForMonthly();
        return new GetAvgRentPriceForMonthlyQueryResult()
        {
            AvgPriceForMonthly = values
        };
    }
}