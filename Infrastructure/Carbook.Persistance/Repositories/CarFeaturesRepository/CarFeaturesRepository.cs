using Carbook.Application.Repositories.CarFeauresRepository;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistance.Repositories.CarFeaturesRepository;

public class CarFeaturesRepository  : ICarFeaturesRepositrory
{
    private readonly CarBookDbContext  _dbContext;

    public CarFeaturesRepository( CarBookDbContext dbContext)
    {
         _dbContext = dbContext;
    }
    public async Task<List<CarFeatures>> GetCarFeaturesByCarId(string carId)
    {
        var values =  _dbContext.CarFeatures.Include(x=>x.Features).Where(f => f.CarId == carId).ToList();
        return values;
    }
}