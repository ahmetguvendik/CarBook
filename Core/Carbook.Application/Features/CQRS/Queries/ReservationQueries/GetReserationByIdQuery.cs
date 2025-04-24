using Carbook.Application.Features.CQRS.Results.ReservationResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.ReservationQueries;

public class GetReserationByIdQuery : IRequest<GetReservationByIdQueryResult>
{
    public string Id { get; set; }

    public GetReserationByIdQuery(string id)
    {
        Id = id;
    }
}