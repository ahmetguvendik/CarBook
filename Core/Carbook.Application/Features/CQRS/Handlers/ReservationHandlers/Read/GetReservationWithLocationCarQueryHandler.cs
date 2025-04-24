using Carbook.Application.Features.CQRS.Queries.ReservationQueries;
using Carbook.Application.Features.CQRS.Results.ReservationResults;
using Carbook.Application.Repositories.ReservationRepositories;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ReservationHandlers.Read;

public class GetReservationWithLocationCarQueryHandler : IRequestHandler<GetReservationQuery,List<GetReservationQueryResult>>
{
    private readonly IReservationRepository _reservationRepository;

    public GetReservationWithLocationCarQueryHandler(IReservationRepository reservationRepository)
    {
         _reservationRepository = reservationRepository;
    }

    public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request,
          CancellationToken cancellationToken)
    {
        var reservations = await _reservationRepository.GetReservationWithLocationCar();
        return reservations.Select(x => new GetReservationQueryResult
        {
             Id = x.Id,
            CarName = x.Car.Model,
            Age = x.Age,
            DriverLicanceYear = x.DriverLicanceYear,
            Statues = x.Statues,
            NameSurname = x.NameSurname,
            DropOffLocationName = x.DrofOffLocation.Name,
            PickUpLocationName = x.PickUpLocation.Name,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            Message = x.Message,
            
            
        }).ToList();

    }
}