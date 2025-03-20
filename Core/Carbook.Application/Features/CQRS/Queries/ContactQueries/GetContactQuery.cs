using Carbook.Application.Features.CQRS.Results.ContactResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.ContactQueries;

public class GetContactQuery : IRequest<List<GetContactQueryResult>>
{
    
}