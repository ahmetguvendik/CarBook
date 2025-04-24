using CarBook.Domain.Entities;

namespace Carbook.Application.Repositories.ReservationRepositories;

public interface IReservationRepository
{
    Task<List<Reservation>> GetReservationWithLocationCar();    
}