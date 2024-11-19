using System;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers.Write
{
	public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
	{
        private readonly IRepository<Domain.Entities.Pricing> _repository;
		public UpdatePricingCommandHandler(IRepository<Domain.Entities.Pricing> repository)
		{
            _repository = repository;
		}

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
            await _repository.SaveChangesAsync();
        }
    }
}

