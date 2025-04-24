using System;
using CarBook.Domain.Entities;

namespace CarBook.Application.Repositories.CarPricingReposiyories
{
	public interface ICarPricingRepository
	{
		Task<List<CarPricing>> GetCarPricingsWithCarDailyPrice();
		Task<List<CarPricing>> GetCarPricingsWithCar();
	}
}

