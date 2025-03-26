using CarBook.Application.Repositories.CarRepositories;
using Carbook.Application.Repositories.StatisticsRepositories;
using CarBook.Persistance.Context;

namespace Carbook.Persistance.Repositories.StatisticsRepository;

public class StatisticsRepository : IStatisticsRepository
{
    private readonly CarBookDbContext  _context;

    public StatisticsRepository(CarBookDbContext  context)
    {
          _context = context;
    }
    public int GetCarCount()
    {
        var value = _context.Cars.Count();
        return value;
    }

    public int GetLocationCount()
    {
        var  value = _context.Locations.Count();
        return value;
    }

    public int GetAuthorCount()
    {
        var value = _context.Authors.Count();
        return value;
    }

    public int GetBlogCount()
    {
        var value = _context.Blogs.Count();
        return value;
    }

    public int GetBrandCount()
    {
        var value = _context.Brands.Count();
        return value;
    }

    public decimal GetAvgRentPriceForDaily()
    {
       var id = _context.Pricings.Where(x => x.Name == "Gunluk").Select(y=>y.Id).First();
       decimal averagePrice = _context.CarPricings
           .Where(x => x.PricingId == id)
           .Select(x => decimal.Parse(x.Price))  // Convert string to decimal
           .Average();
        return averagePrice;
    }

    public string GetAvgRentPriceForWeekly()
    {
        throw new NotImplementedException();
    }

    public string GetAvgRentPriceForMonthly()
    {
        throw new NotImplementedException();
    }

    public int GetCountByTranmissionIsAuto()
    {
        throw new NotImplementedException();
    }

    public string GetBrandNameByMaxCar()
    {
        throw new NotImplementedException();
    }

    public string GetBlogTitleByMaxBlogComment()
    {
        throw new NotImplementedException();
    }

    public int GetCarCountByKmSmallerThan1000()
    {
        throw new NotImplementedException();
    }

    public int GetCarCountByFuelElectric()
    {
        throw new NotImplementedException();
    }
}