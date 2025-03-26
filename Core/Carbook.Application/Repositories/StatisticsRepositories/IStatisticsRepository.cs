namespace Carbook.Application.Repositories.StatisticsRepositories;

public interface IStatisticsRepository
{
    int GetCarCount();
    int GetLocationCount();
    int GetAuthorCount();
    int GetBlogCount();
    int GetBrandCount();
    decimal GetAvgRentPriceForDaily();
    string GetAvgRentPriceForWeekly();
    string GetAvgRentPriceForMonthly();
    int GetCountByTranmissionIsAuto();
    string GetBrandNameByMaxCar();
    string GetBlogTitleByMaxBlogComment();
    int GetCarCountByKmSmallerThan1000();
    int GetCarCountByFuelElectric();
}