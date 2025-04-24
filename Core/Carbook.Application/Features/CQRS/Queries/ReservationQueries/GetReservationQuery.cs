using Carbook.Application.Features.CQRS.Results.ReservationResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.ReservationQueries;
 
public class GetReservationQuery : IRequest<List<GetReservationQueryResult>>
{

}