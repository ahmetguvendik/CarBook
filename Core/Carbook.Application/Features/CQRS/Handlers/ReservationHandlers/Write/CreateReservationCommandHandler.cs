using Carbook.Application.Features.CQRS.Commands.ReservationCommands;
using Carbook.Application.Features.CQRS.Results.ReservationResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ReservationHandlers.Write;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
{
    private readonly IRepository<Reservation> _reservationRepository;

    public CreateReservationCommandHandler(IRepository<Reservation> reservationRepository)
    {
         _reservationRepository = reservationRepository;
    }
    public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = new Reservation();
        reservation.Id = Guid.NewGuid().ToString();
        reservation.NameSurname = request.NameSurname;
        reservation.Email = request.Email;
        reservation.PhoneNumber = request.PhoneNumber;
        reservation.CarId  = request.CarId;
        reservation.DriverLicanceYear  = request.DriverLicanceYear;
        reservation.Age  = request.Age;
        reservation.Message = request.Message;
        reservation.DropOffLocationId  = request.DropOffLocationId;
        reservation.PickUpLocationId  = request.PickUpLocationId;
        reservation.Statues = "Rezervasyon Alındı";
        await _reservationRepository.CreateAsync(reservation);
        await _reservationRepository.SaveChangesAsync();

    }
}