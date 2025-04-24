using Carbook.Application.Features.CQRS.Queries.ContactQueries;
using Carbook.Application.Features.CQRS.Results.ContactResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ContactHandlers.Read;

public class GetContactQueryHandler : IRequestHandler<GetContactQuery,List<GetContactQueryResult>>
{
    private readonly IRepository<Contact>  _repository;

    public GetContactQueryHandler( IRepository<Contact> repository)
    {
         _repository = repository;
    }
    public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetContactQueryResult
        {
            Id = x.Id,
            Name = x.Name,
            DateTime = x.DateTime,
            Email = x.Email,
            Description = x.Description,
            Subject = x.Subject,    
        }).ToList();
    }
}