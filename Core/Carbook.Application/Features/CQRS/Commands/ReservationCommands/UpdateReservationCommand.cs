using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.ReservationCommands;

public class UpdateReservationCommand : IRequest
{
    public string Id { get; set; }
    public string Statues { get; set; }
}