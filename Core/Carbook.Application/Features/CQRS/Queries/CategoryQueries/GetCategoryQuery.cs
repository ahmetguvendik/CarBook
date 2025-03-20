using Carbook.Application.Features.CQRS.Results.CategoryResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.CategoryQueries;

public class GetCategoryQuery : IRequest<List<GetCategoryQueryResult>>
{
    
}