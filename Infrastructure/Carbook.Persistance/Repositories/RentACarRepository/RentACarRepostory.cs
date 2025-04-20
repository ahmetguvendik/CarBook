using System.Linq.Expressions;
using CarBook.Domain.Entities;
using Carbook.Application.Repositories.RentACarRepositories;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistance.Repositories.RentACarRepository;

public class RentACarRepostory : IRentACarRepository
{
    private readonly CarBookDbContext _context;

    public RentACarRepostory(CarBookDbContext context)
    {
        _context = context;
    }

    public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
    {
        return await _context.RentACars.Where(filter).Include(x=>x.Car).ThenInclude(y=>y.Brand).ToListAsync();
    }
}
