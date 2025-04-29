using CarBook.Application.Features.Mediator.Results.CarResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarQueries;

public class GetCarWithBrandsByIdQuery : IRequest<GetCarWithBrandsByIdQueryResult>
{
    public string Id { get; set; }

    public GetCarWithBrandsByIdQuery(string id)
    {
         Id = id;
    }
}