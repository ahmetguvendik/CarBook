using CarBook.Domain.Entities;

namespace Carbook.Application.Repositories.CarFeauresRepository;

public interface ICarFeaturesRepositrory
{
    Task<List<CarFeatures>> GetCarFeaturesByCarId(string carId);
}