using Carbook.Application.Features.CQRS.Queries.AboutQueries;
using Carbook.Application.Features.CQRS.Results.AboutResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.AboutHandlers.Read;

public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery,List<GetAboutQueryResult>>
{
    private readonly IRepository<About> _repository;

    public GetAboutQueryHandler( IRepository<About> repository)
    {
         _repository = repository;
    }
    public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetAllAsync();
        return value.Select(x => new GetAboutQueryResult
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            ImageURL = x.ImageURL,
            
        }).ToList();
    }
}