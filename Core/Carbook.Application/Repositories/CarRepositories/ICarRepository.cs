using System;
using CarBook.Domain.Entities;

namespace CarBook.Application.Repositories.CarRepositories
{
	public interface ICarRepository
	{
        Task<List<Car>> GetCarWithBrands();
        Task<List<Car>> Get5CarWithBrands();
        int CarCount();
        Task<Car> GetCarWithBrandsById(string id);
	}
}

