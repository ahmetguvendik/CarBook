using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using Carbook.Application.Repositories.StatisticsRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountQueryResult>
{
    private readonly IStatisticsRepository  _statisticsRepository;

    public GetLocationCountQueryHandler(IStatisticsRepository statisticsRepository)
    {
         _statisticsRepository = statisticsRepository;
    }
    public async Task<GetLocationCountQueryResult> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticsRepository.GetLocationCount();
        return new GetLocationCountQueryResult()
        {
            LocationCount = value
        };
    }
}