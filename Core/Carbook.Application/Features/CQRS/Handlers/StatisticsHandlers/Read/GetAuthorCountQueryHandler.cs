using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using Carbook.Application.Repositories.StatisticsRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
{
    private readonly IStatisticsRepository  _statisticsRepository;

    public GetAuthorCountQueryHandler(IStatisticsRepository statisticsRepository)
    {
         _statisticsRepository = statisticsRepository;
    }
    public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
    {
        var value = _statisticsRepository.GetAuthorCount();
        return new GetAuthorCountQueryResult()
        {
            AuthorCount = value
        };
    }
}