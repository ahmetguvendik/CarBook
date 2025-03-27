using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.BrandResults;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using Carbook.Application.Repositories.StatisticsRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
{
    private readonly IStatisticsRepository  _statisticsRepository;

    public GetBrandCountQueryHandler(IStatisticsRepository statisticsRepository)
    {
         _statisticsRepository = statisticsRepository;
    }
    public async Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticsRepository.GetBrandCount();
        return new GetBrandCountQueryResult()
        {
            BrandCount = value
        };
    }
}