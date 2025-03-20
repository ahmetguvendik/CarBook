using Carbook.Application.Features.CQRS.Results.AboutResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.AboutQueries;

public class GetAboutQuery: IRequest<List<GetAboutQueryResult>>
{
    
}