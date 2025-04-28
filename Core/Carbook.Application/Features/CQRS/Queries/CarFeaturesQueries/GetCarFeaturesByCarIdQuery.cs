using Carbook.Application.Features.CQRS.Results.CarFeauresResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.CarFeaturesQueries;

public class GetCarFeaturesByCarIdQuery : IRequest<List<GetCarFeaturesByCarIdResult>>
{
    public string Id { get; set; }

    public GetCarFeaturesByCarIdQuery(string id)
    {
         Id = id;
    }
}