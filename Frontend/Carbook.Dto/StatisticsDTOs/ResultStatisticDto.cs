namespace Carbook.Dto.StatisticsDTOs;

public class ResultStatisticDto
{
    public int carCount { get; set; }
    public int locationCount { get; set; }
    public int authorCount { get; set; }
    public int blogCount { get; set; }
    public int brandCount { get; set; }
    public decimal avgPriceForDaily { get; set; }
    public decimal avgPriceForWeekly { get; set; }
    public decimal avgPriceForMonthly { get; set; }
    public int fuelEletricCount { get; set; }
    public int autoCarCount { get; set; }
    public int countKmSmallerThan1000 { get; set; }
}