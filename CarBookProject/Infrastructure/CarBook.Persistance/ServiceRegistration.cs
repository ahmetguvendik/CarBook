using System;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers.Write;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers.Write;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers.Write;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers.Write;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Read;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers.Write;
using CarBook.Application.Repositories;
using CarBook.Persistance.Context;
using CarBook.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarBook.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection collection)
        {
            collection.AddDbContext<CarBookDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=CarBookDb;"));
            collection.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            collection.AddScoped<GetAboutQueryHandler>();
            collection.AddScoped<GetAboutByIdQueryHandler>();
            collection.AddScoped<CreateAboutCommandHandler>();
            collection.AddScoped<UpdateAboutCommandHandler>();
            collection.AddScoped<DeleteAboutCommandHandler>();

            collection.AddScoped<GetBannerQueryHandler>();
            collection.AddScoped<GetBannerByIdQueryHandler>();
            collection.AddScoped<CreateBannerCommandHandler>();
            collection.AddScoped<UpdateBannerCommandHandler>();
            collection.AddScoped<RemoveBannerCommandHandler>();

            collection.AddScoped<GetBrandQueryCommand>();
            collection.AddScoped<GetBrandByIdQueryHandler>();
            collection.AddScoped<CreateBrandCommandHandler>();
            collection.AddScoped<UpdateBrandCommandHandler>();
            collection.AddScoped<RemoveBrandCommandHandler>();

            collection.AddScoped<GetCategoryQueryHandler>();
            collection.AddScoped<GetCategoryByIdQueryHandler>();
            collection.AddScoped<CreateCategoryCommandHandler>();
            collection.AddScoped<UpdateCategoryCommandHandler>();
            collection.AddScoped<RemoveCategoryCommandHandler>();

            collection.AddScoped<GetContactQueryHandler>();
            collection.AddScoped<GetContactByIdQueryHandler>();
            collection.AddScoped<CreataContactCommandHandler>();
            collection.AddScoped<UpdateContactCommandHandler>();
            collection.AddScoped<RemoveContactCommandHandler>();

        }
    }
}

