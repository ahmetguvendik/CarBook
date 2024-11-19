using System;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.Write
{
	public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
	{
        private readonly IRepository<Domain.Entities.Pricing> _repository;
		public CreatePricingCommandHandler(IRepository<Domain.Entities.Pricing> repository)
		{
            _repository = repository;    
		}

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {

            var value = new Pricing();
            value.Id = Guid.NewGuid().ToString();
            value.Name = request.Name;
            await _repository.CreateAsync(value);
            await _repository.SaveChangesAsync();
        }
    }
}

