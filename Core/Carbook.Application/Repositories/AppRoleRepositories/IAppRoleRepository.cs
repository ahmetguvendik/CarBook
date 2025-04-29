using System.Linq.Expressions;
using CarBook.Domain.Entities;

namespace Carbook.Application.Repositories.AppRoleRepositories;

public interface IAppRoleRepository
{
    Task<AppRole> GetByFilterAsync(Expression<Func<AppRole, bool>> filter);   

}