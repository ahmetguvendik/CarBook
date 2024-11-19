using System;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.Write
{
	public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
	{
        private readonly IRepository<Domain.Entities.Pricing> _repository;
		public RemovePricingCommandHandler(IRepository<Domain.Entities.Pricing> repository)
		{
            _repository = repository;
		}

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
            await _repository.SaveChangesAsync();
        }
    }
}

