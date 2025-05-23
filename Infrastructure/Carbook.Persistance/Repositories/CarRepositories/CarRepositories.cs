﻿using System;
using CarBook.Application.Repositories.CarRepositories;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories.CarRepositories
{
	public class CarRepositories : ICarRepository
	{
        private readonly CarBookDbContext _carBookDbContext;
		public CarRepositories(CarBookDbContext carBookDbContext)
		{
            _carBookDbContext = carBookDbContext;
		}

        public async Task<List<Car>> Get5CarWithBrands()
        {
            var cars = _carBookDbContext.Cars.Include(x => x.Brand).Take(5).ToList();
            return cars;
        }

        public int CarCount()
        {
            var count = _carBookDbContext.Cars.Count();
            return count;
        }

        public async Task<Car> GetCarWithBrandsById(string id)
        {
           var value = _carBookDbContext.Cars.Include(x => x.Brand).Where(x => x.Id == id).FirstOrDefault();
           return value;
        }

        public async Task<List<Car>> GetCarWithPrice()
        {
            var cars = _carBookDbContext.Cars.Include(x => x.Brand).Include(y=>y.CarPricings).ThenInclude(z=>z.Pricing).ToList();
            return cars;
        }

        public async Task<List<Car>> GetCarWithBrands()
        {
            var cars = _carBookDbContext.Cars.Include(x => x.Brand).ToList();
            return cars;
        }
    }
}

