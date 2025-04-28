using Carbook.Application.Features.CQRS.Queries.CarFeaturesQueries;
using Carbook.Application.Features.CQRS.Results.CarFeauresResults;
using Carbook.Application.Repositories.CarFeauresRepository;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.CarFeauresHandlers;

public class GetCarFeaturesByCarIdQueryHandler : IRequestHandler<GetCarFeaturesByCarIdQuery, List<GetCarFeaturesByCarIdResult>>
{
    private readonly ICarFeaturesRepositrory  _carFeaturesRepositrory;

    public GetCarFeaturesByCarIdQueryHandler(ICarFeaturesRepositrory carFeaturesRepositrory)
    {
         _carFeaturesRepositrory = carFeaturesRepositrory;
    }
    public async Task<List<GetCarFeaturesByCarIdResult>> Handle(GetCarFeaturesByCarIdQuery request, CancellationToken cancellationToken)
    {
       var values = await _carFeaturesRepositrory.GetCarFeaturesByCarId(request.Id);
       return values.Select(x => new GetCarFeaturesByCarIdResult()
       {
         CarId = x.CarId,
         FeaturesName = x.Features.Name,
         IsAvaible = x.IsAvaible,
         Id = x.Id,
         
       }).ToList();
    }
}