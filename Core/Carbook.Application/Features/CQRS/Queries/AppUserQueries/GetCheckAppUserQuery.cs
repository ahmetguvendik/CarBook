using Carbook.Application.Features.CQRS.Results.AppUserResult;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.AppUserQueries;

public class GetCheckAppUserQuery : IRequest<GetCheckAppUserQueryResult>
{
    public string Username { get; set; }
    public string Password { get; set; }
    
    
}