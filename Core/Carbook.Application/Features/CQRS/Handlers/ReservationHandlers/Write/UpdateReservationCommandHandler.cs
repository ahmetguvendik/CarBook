using Carbook.Application.Features.CQRS.Commands.ReservationCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ReservationHandlers.Write;

public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
{
    private readonly IRepository<Reservation> _reservationRepository;

    public UpdateReservationCommandHandler(IRepository<Reservation> reservationRepository)
    {
         _reservationRepository = reservationRepository;
    }
    
    public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var value = await _reservationRepository.GetByIdAsync(request.Id);
        value.Statues = request.Statues;
        await _reservationRepository.UpdateAsync(value);
        await _reservationRepository.SaveChangesAsync();
    }
}