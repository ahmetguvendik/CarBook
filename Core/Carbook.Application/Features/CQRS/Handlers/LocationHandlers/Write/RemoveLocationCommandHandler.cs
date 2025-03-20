using Carbook.Application.Features.CQRS.Commands.LocationCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.LocationHandlers.Write;

public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
{
    private readonly IRepository<Location> _repository;

    public RemoveLocationCommandHandler( IRepository<Location> repository)
    {
         _repository = repository;
    }
    public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.RemoveAsync(value);
    }
}