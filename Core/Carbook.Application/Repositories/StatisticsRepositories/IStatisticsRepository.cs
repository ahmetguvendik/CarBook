namespace Carbook.Application.Repositories.StatisticsRepositories;

public interface IStatisticsRepository
{
    int GetCarCount();
    int GetLocationCount();
    int GetAuthorCount();
    int GetBlogCount();
    int GetBrandCount();
    decimal GetAvgRentPriceForDaily();
    decimal GetAvgRentPriceForWeekly();
    decimal GetAvgRentPriceForMonthly();
    int GetCountByTranmissionIsAuto();
    int GetCarCountByKmSmallerThan1000();
    int GetCarCountByFuelElectric();
}