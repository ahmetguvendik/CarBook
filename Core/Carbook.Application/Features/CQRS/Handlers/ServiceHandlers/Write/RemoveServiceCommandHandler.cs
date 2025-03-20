using Carbook.Application.Features.CQRS.Commands.ServiceCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ServiceHandlers.Write;

public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
{
    private readonly IRepository<Service> _serviceRepository;

    public RemoveServiceCommandHandler(IRepository<Service> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    

    public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
    {
        var value = await _serviceRepository.GetByIdAsync(request.Id);
        await _serviceRepository.RemoveAsync(value);    
        
    }
}