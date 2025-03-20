using Carbook.Application.Features.CQRS.Results.ServiceResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.ServiceQueries;

public class GetServiceQuery : IRequest<List<GetServiceQueryResult>>
{
    
}