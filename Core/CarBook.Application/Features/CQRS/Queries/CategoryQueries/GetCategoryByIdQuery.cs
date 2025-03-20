using Carbook.Application.Features.CQRS.Results.CategoryResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.CategoryQueries;

public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResult>
{
    public string Id { get; set; }

    public GetCategoryByIdQuery(string id)
    {
         Id = id;
    }
}