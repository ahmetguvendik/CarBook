using Carbook.Application.Features.CQRS.Results.ServiceResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.ServiceQueries;

public class GetServiceByIdQuery : IRequest<GetServiceByIdQueryResult>
{
    public string Id { get; set; }

    public GetServiceByIdQuery(string id)
    {
        Id = id;
    }
}