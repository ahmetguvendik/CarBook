using Carbook.Application.Features.CQRS.Commands.ServiceCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ServiceHandlers.Write;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
{
    private readonly IRepository<Service> _serviceRepository;

    public CreateServiceCommandHandler(IRepository<Service> serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }
    
    public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Service();
        service.Id = Guid.NewGuid().ToString();
        service.Title = request.Title;
        service.Description = request.Description;
        service.IconURL = request.IconURL;
        await _serviceRepository.CreateAsync(service);
    }
}