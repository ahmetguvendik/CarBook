using System;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers.Write
{
	public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
	{
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync(request.Id);
            service.Title = request.Title;
            service.IconURL = request.IconURL;
            service.Description = request.Description;
            await _repository.UpdateAsync(service);
        }
    }
}

