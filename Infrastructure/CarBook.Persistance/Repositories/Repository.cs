using System;
using CarBook.Application.Repositories;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
        private readonly CarBookDbContext _carBookDbContext;
		public Repository(CarBookDbContext carBookDbContext)
		{
            _carBookDbContext = carBookDbContext;
		}

        public async Task CreateAsync(T entity)
        {
            _carBookDbContext.Add(entity);
            await _carBookDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _carBookDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _carBookDbContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _carBookDbContext.Set<T>().Remove(entity);
            await _carBookDbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _carBookDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _carBookDbContext.Set<T>().Update(entity);
            await _carBookDbContext.SaveChangesAsync();
        }
    }
}

