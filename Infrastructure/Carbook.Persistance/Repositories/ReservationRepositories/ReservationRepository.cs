using Carbook.Application.Repositories.ReservationRepositories;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.ReservationRepositories;

public class ReservationRepository : IReservationRepository
{
    private readonly CarBookDbContext _context;

    public ReservationRepository(CarBookDbContext context)
    {
        _context = context;
    }

    public async Task<List<Reservation>> GetReservationWithLocationCar()
    {
        return await _context.Reservations
            .Include(x => x.PickUpLocation)
            .Include(x => x.DrofOffLocation)
            .Include(x => x.Car)
            .ToListAsync();
    }
}