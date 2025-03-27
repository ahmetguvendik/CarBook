using Carbook.Application.Features.CQRS.Results.BrandResults;
using Carbook.Application.Features.CQRS.Results.StatisticsResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.StatisticsQueries;

public class GetBrandCountQuery : IRequest<GetBrandCountQueryResult>
{
    
}