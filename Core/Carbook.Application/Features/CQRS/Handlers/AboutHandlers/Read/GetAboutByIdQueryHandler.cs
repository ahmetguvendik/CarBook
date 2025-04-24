using Carbook.Application.Features.CQRS.Queries.AboutQueries;
using Carbook.Application.Features.CQRS.Results.AboutResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.AboutHandlers.Read;

public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery,GetAboutByIdQueryResult>
{
    private readonly IRepository<About> _repository;

    public GetAboutByIdQueryHandler( IRepository<About> repository)
    {
       _repository = repository;          
    }
    public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetAboutByIdQueryResult()
        {
            Id = value.Id,
            ImageURL = value.ImageURL,
            Description = value.Description,
            Title = value.Title,
        };
    }
}