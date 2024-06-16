using System;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers.Write
{
	public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
	{
        private readonly IRepository<Service> _repository;
            
		public CreateServiceCommandHandler(IRepository<Service> repository)
		{
            _repository = repository;
		}

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = new Service();
            service.Id = Guid.NewGuid().ToString();
            service.Title = request.Title;
            service.IconURL = request.IconURL;
            service.Description = request.Description;
            await _repository.CreateAsync(service);
        }
    }
}

