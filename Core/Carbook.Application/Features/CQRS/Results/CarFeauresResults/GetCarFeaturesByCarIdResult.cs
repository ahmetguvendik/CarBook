namespace Carbook.Application.Features.CQRS.Results.CarFeauresResults;

public class GetCarFeaturesByCarIdResult
{
    public string Id { get; set; }
    public string CarId { get; set; }
    public string FeaturesId { get; set; }
    public string FeaturesName { get; set; }  
    public bool IsAvaible { get; set; }	
}