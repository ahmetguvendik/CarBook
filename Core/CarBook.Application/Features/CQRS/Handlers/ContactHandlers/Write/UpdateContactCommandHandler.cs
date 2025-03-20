using Carbook.Application.Features.CQRS.Commands.ContactCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ContactHandlers.Write;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
{
    private readonly IRepository<Contact> _repository;

    public UpdateContactCommandHandler( IRepository<Contact> repository)
    {
         _repository = repository;
    }
    public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        value.Email = request.Email;
        value.Description = request.Description;
        value.Subject = request.Subject;
        value.DateTime = request.DateTime;
        await _repository.UpdateAsync(value);
    }
}