using System;
using CarBook.Application.Repositories.CarPricingReposiyories;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
        private readonly CarBookDbContext _carBookDbContext;
		public CarPricingRepository(CarBookDbContext carBookDbContext)
		{
            _carBookDbContext = carBookDbContext;
		}

        public async Task<List<CarPricing>> GetCarPricingsWithCarDailyPrice()
        {
            var values = _carBookDbContext.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(a=>a.PricingId == "1").ToList();
            return values;
        }

        public async Task<List<CarPricing>> GetCarPricingsWithCar()
        {
	        var values = _carBookDbContext.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z=>z.Pricing).ToList();
	        return values;
        }
	}
}

