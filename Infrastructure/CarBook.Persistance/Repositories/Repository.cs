using Carbook.Application.Repositories;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistance.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CarBookDbContext _dbContext;

    public Repository(CarBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }  
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync(); 
    }

    public async Task<T> GetByIdAsync(string id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task CreateAsync(T entity)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}