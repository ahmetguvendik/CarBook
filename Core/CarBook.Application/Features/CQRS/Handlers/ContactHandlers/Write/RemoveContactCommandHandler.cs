using Carbook.Application.Features.CQRS.Commands.ContactCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ContactHandlers.Write;

public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand>
{
    private readonly IRepository<Contact> _repository;

    public RemoveContactCommandHandler( IRepository<Contact> repository)
    {
          _repository = repository;
    }
    public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}