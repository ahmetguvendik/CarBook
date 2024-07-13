using System;
using System.Collections.Generic;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveChangesAsync();
    }
    
}

