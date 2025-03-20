using Carbook.Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.LocationQueries;

public class GetLocationQuery : IRequest<List<GetLocationQueryResult>>
{
    
}