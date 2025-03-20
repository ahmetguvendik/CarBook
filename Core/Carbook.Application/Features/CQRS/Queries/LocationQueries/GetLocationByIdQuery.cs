using Carbook.Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.LocationQueries;

public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
{
    public string Id { get; set; }

    public GetLocationByIdQuery(string id)
    {
         Id = id;
    }
}