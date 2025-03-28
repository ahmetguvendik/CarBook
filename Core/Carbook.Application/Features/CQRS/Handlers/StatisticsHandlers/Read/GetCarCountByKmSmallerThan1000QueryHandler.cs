using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using Carbook.Application.Repositories.StatisticsRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetCarCountByKmSmallerThan1000QueryHandler : IRequestHandler<GetCarCountByKmSmallerThan1000Query,GetCarCountByKmSmallerThan1000QueryResult>
{
    private readonly IStatisticsRepository  _statisticsRepository;

    public GetCarCountByKmSmallerThan1000QueryHandler(IStatisticsRepository statisticsRepository)
    {
         _statisticsRepository = statisticsRepository;
    }
    public async Task<GetCarCountByKmSmallerThan1000QueryResult> Handle(GetCarCountByKmSmallerThan1000Query request, CancellationToken cancellationToken)
    {
       var value = _statisticsRepository.GetCarCountByKmSmallerThan1000();
       return new GetCarCountByKmSmallerThan1000QueryResult()
       {
           CountKmSmallerThan1000 = value
       };
    }
}