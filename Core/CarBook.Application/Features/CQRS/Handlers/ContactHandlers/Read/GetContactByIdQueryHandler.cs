using Carbook.Application.Features.CQRS.Queries.ContactQueries;
using Carbook.Application.Features.CQRS.Results.ContactResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ContactHandlers.Read;

public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
{
    private readonly IRepository<Contact> _repository;

    public GetContactByIdQueryHandler( IRepository<Contact> repository)
    {
         _repository = repository;
    }
    public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetContactByIdQueryResult()
        {
            Id = value.Id,
            Name = value.Name,
            Email = value.Email,
            DateTime = value.DateTime,
            Description = value.Description,
            Subject = value.Subject,

        };
    }
}