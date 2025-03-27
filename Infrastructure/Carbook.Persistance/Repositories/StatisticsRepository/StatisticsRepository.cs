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
       var id = _context.Pricings.Where(x => x.Name == "Gunluk").Select(y=>y.Id).FirstOrDefault();
       decimal averagePrice = _context.CarPricings
           .Where(x => x.PricingId == id)
           .Select(x => (x.Price))  // Convert string to decimal
           .Average();
        return averagePrice;
    }

    public decimal GetAvgRentPriceForWeekly()
    {
        var id = _context.Pricings.Where(x => x.Name == "Haftalik").Select(y=>y.Id).FirstOrDefault();
        decimal averagePrice = _context.CarPricings
            .Where(x => x.PricingId == id)
            .Select(x => (x.Price))  // Convert string to decimal
            .Average();
        return averagePrice;
    }

    public decimal GetAvgRentPriceForMonthly()
    {
        var id = _context.Pricings.Where(x => x.Name == "Aylik").Select(y=>y.Id).FirstOrDefault();
        decimal averagePrice = _context.CarPricings
            .Where(x => x.PricingId == id)
            .Select(x => (x.Price))  // Convert string to decimal
            .Average();
        return averagePrice;
    }

    public int GetCountByTranmissionIsAuto()
    {
        var count = _context.Cars.Where(x => x.Vites =="Otomatik").Count();
        return count;
    }
    

    public int GetCarCountByKmSmallerThan1000()
    {
        var value = _context.Cars.Where(x => x.Km <=1000).Count();
        return value;
    }

    public int GetCarCountByFuelElectric()
    {
        var count = _context.Cars.Where(x => x.Fuel =="Elektrik").Count();
        return count;
    }
}