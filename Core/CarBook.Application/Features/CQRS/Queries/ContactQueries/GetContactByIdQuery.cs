using Carbook.Application.Features.CQRS.Results.ContactResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.ContactQueries;

public class GetContactByIdQuery : IRequest<GetContactByIdQueryResult>
{
    public string Id { get; set; }

    public GetContactByIdQuery(string id)
    {
         Id = id;
    }
}