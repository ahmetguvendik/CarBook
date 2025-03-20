using Carbook.Application.Features.CQRS.Commands.ContactCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ContactHandlers.Write;

public class CreateContactCommadHandler : IRequestHandler<CreateContactCommand>
{
    private readonly IRepository<Contact> _repository;

    public CreateContactCommadHandler( IRepository<Contact> repository)
    {
         _repository = repository;
    }
    public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact();
        contact.Id = Guid.NewGuid().ToString();
        contact.Name = request.Name;
        contact.Email = request.Email;
        contact.Description = request.Description;
        contact.Subject = request.Subject;
        contact.DateTime = request.DateTime;
        await _repository.CreateAsync(contact);
        
    }
}