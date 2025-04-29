using System.Linq.Expressions;
using Carbook.Application.Repositories.AppUserRepositories;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistance.Repositories.AppUserRepositories;

public class AppUserRepository : IAppUserRepository
{
    private readonly CarBookDbContext  _context;

    public AppUserRepository( CarBookDbContext context)
    {
         _context = context;
    }
    
    public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
    {
        return await _context.AppUsers.Where(filter).FirstOrDefaultAsync();
    }
}