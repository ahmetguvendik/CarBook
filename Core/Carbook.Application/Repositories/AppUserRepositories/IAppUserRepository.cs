using System.Linq.Expressions;
using CarBook.Domain.Entities;

namespace Carbook.Application.Repositories.AppUserRepositories;

public interface IAppUserRepository
{
    Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);   
}