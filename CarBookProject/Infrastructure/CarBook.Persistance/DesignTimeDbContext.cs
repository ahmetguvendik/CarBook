using System;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarBook.Persistance
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<CarBookDbContext>
    {

        public CarBookDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CarBookDbContext> dbContextOptions = new();
            dbContextOptions.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=CarBookDb;");
            return new(dbContextOptions.Options);
        }
    }
}

