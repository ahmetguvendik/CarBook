using Carbook.Application.Features.CQRS.Results.AboutResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.AboutQueries;

public class GetAboutByIdQuery : IRequest<GetAboutByIdQueryResult>
{
    public string Id { get; set; }
    public GetAboutByIdQuery(string id)
    {
        Id = id;
    }
}