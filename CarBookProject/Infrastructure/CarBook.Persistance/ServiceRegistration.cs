using System;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection collection)
        {
            collection.AddDbContext<CarBookDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=CarBookDb;"));
            //collection.AddScoped<IActivityWriteRepository > 
        }
    }
}

