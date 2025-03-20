using Carbook.Application.Features.CQRS.Results.BrandResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.BrandQueries;

public class GetBrandQuery : IRequest<List<GetBrandQueryResult>>
{
    
}