using Carbook.Application.Repositories;
using CarBook.Application.Repositories.BlogRepository;
using CarBook.Application.Repositories.CarPricingReposiyories;
using CarBook.Application.Repositories.CarRepositories;
using CarBook.Application.Repositories.GenericRepository;
using Carbook.Application.Repositories.RentACarRepositories;
using Carbook.Application.Repositories.ReservationRepositories;
using Carbook.Application.Repositories.StatisticsRepositories;
using Carbook.Application.Services;
using CarBook.Persistance.Context;
using Carbook.Persistance.Repositories;
using CarBook.Persistance.Repositories.BlogRepository;
using CarBook.Persistance.Repositories.CarPricingRepositories;
using CarBook.Persistance.Repositories.CarRepositories;
using CarBook.Persistance.Repositories.CommentRepository;
using Carbook.Persistance.Repositories.RentACarRepository;
using CarBook.Persistance.Repositories.ReservationRepositories;
using Carbook.Persistance.Repositories.StatisticsRepository;
using Carbook.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Carbook.Persistance;

public static class ServiceRegistration
{
    public static void AddPersistanceService(this IServiceCollection collection)
    {
        collection.AddDbContext<CarBookDbContext>(opt =>
            opt.UseNpgsql("User ID=postgres;Password=testtest;Host=localhost;Port=5432;Database=CarBookDb;"));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        collection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        collection.AddScoped(typeof(ICarRepository), typeof(CarRepositories));
        collection.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
        collection.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
        collection.AddScoped(typeof(ICommentRepository), typeof(CommentRepository));
        collection.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));
        collection.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepostory));
        collection.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));
        collection.AddScoped(typeof(IEmailService), typeof(EmailService));
    }
}