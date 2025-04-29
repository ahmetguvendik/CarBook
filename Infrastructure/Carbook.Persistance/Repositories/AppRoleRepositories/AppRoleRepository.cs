using System.Linq.Expressions;
using Carbook.Application.Repositories.AppRoleRepositories;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistance.Repositories.AppRoleRepositories;

public class AppRoleRepository  : IAppRoleRepository
{
    private readonly CarBookDbContext  _context;

    public AppRoleRepository(CarBookDbContext context)
    {
         _context = context;
    }
    public async Task<AppRole> GetByFilterAsync(Expression<Func<AppRole, bool>> filter)
    {
        return await _context.AppRoles.Where(filter).FirstOrDefaultAsync();

    }
}