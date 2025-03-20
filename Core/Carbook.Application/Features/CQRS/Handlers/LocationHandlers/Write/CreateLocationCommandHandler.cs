using Carbook.Application.Features.CQRS.Commands.LocationCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.LocationHandlers.Write;

public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public CreateLocationCommandHandler( IRepository<Location> repository)
    {
         _repository = repository;
    }
    
    public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var location = new Location();
        location.Id = Guid.NewGuid().ToString();
        location.Name = request.Name;
        await _repository.CreateAsync(location);
        
    }
}