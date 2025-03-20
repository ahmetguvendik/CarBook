using Carbook.Application.Features.CQRS.Commands.ServiceCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ServiceHandlers.Write;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
{
    private readonly IRepository<Service> _repository;

    public UpdateServiceCommandHandler(IRepository<Service> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Title  = request.Title;
        value.Description = request.Description;
        value.IconURL  = request.IconURL;
        await _repository.UpdateAsync(value);
    }
}