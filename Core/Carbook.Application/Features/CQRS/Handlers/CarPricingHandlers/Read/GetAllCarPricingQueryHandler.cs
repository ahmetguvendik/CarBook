using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Repositories.CarPricingReposiyories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers.Read;

public class GetAllCarPricingQueryHandler : IRequestHandler<GetAllCarPricingQuery,List<GetAllCarPricingQueryResult>>
{
    private readonly ICarPricingRepository _carPricingRepository;
    public GetAllCarPricingQueryHandler(ICarPricingRepository carPricingRepository)
    {
        _carPricingRepository = carPricingRepository;
    }

    
    public async Task<List<GetAllCarPricingQueryResult>> Handle(GetAllCarPricingQuery request, CancellationToken cancellationToken)
    {
        var values = await _carPricingRepository.GetCarPricingsWithCar();
        return values.Select(x => new GetAllCarPricingQueryResult
        {
            Id = x.Id,
            CarId = x.CarId,
            BrandName = x.Car.Brand.Name,
            CoverImageUrl = x.Car.CoverImageUrl,
            Model = x.Car.Model,
            PriceName = x.Pricing.Name,
            Price =x.Price
            
        }).ToList();
    }
}