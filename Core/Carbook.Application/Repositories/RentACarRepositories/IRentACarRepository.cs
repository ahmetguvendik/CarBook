using System.Linq.Expressions;
using CarBook.Domain.Entities;

namespace Carbook.Application.Repositories.RentACarRepositories;

public interface IRentACarRepository
{
    Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter);   
}