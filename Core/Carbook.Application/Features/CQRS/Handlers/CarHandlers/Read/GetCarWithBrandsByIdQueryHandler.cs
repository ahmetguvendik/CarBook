using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Repositories.CarRepositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers.Read;
 

public class GetCarWithBrandsByIdQueryHandler : IRequestHandler<GetCarWithBrandsByIdQuery, GetCarWithBrandsByIdQueryResult>
{
    private readonly ICarRepository  _carRepository;

    public GetCarWithBrandsByIdQueryHandler(ICarRepository carRepository)
    {
         _carRepository = carRepository;
    }
    public async Task<GetCarWithBrandsByIdQueryResult> Handle(GetCarWithBrandsByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _carRepository.GetCarWithBrandsById(request.Id);
        return new GetCarWithBrandsByIdQueryResult()
        {
            Id = value.Id,
            Fuel = value.Fuel,
            Bagaj = value.Bagaj,
            BrandName = value.Brand.Name,
            DetailImageUrl = value.DetailImageUrl,
            CoverImageUrl = value.CoverImageUrl,
            Model = value.Model,
            Km = value.Km,
            Koltuk = value.Koltuk,

        };
    }
}