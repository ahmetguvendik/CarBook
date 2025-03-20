using Carbook.Application.Features.CQRS.Commands.LocationCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.LocationHandlers.Write;

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public UpdateLocationCommandHandler( IRepository<Location> repository)
    {
          _repository = repository;   
    }
    public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Name = request.Name;
        await _repository.UpdateAsync(value);
    }
}