using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using Carbook.Application.Repositories.StatisticsRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetBlogCountQueryHandler  : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResult>
{
    private readonly IStatisticsRepository _statisticsRepository;

    public GetBlogCountQueryHandler(IStatisticsRepository statisticsRepository)
    {
         _statisticsRepository = statisticsRepository;
    }
    public async Task<GetBlogCountQueryResult> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticsRepository.GetBlogCount();
        return new GetBlogCountQueryResult()
        {
            BlogCount = value
        };
    }
}