using Carbook.Application.Features.CQRS.Queries.StatisticsQueries;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using Carbook.Application.Repositories.StatisticsRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.StatisticsHandlers.Read;

public class GetCountByTranmissionIsAutoQueryHandler : IRequestHandler<GetCountByTranmissionIsAutoQuery,GetCountByTranmissionIsAutoQueryResult>
{
    private readonly IStatisticsRepository  _statisticsRepository;

    public GetCountByTranmissionIsAutoQueryHandler(IStatisticsRepository statisticsRepository)
    {
         _statisticsRepository = statisticsRepository;
    }
    public async Task<GetCountByTranmissionIsAutoQueryResult> Handle(GetCountByTranmissionIsAutoQuery request, CancellationToken cancellationToken)
    {
       var value = _statisticsRepository.GetCountByTranmissionIsAuto();
       return new GetCountByTranmissionIsAutoQueryResult()
       {
           Count = value
       };
    }
}