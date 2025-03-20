using Carbook.Application.Features.CQRS.Results.BrandResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.BrandQueries;

public class GetBrandByIdQuery : IRequest<GetBrandByIdQueryResult>
{
    public string Id { get; set; }

    public GetBrandByIdQuery(string id)
    {
         Id = id;
    }
}