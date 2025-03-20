using System;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using Carbook.Application.Repositories;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers.Write
{
	public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
	{
        private readonly IRepository<Domain.Entities.Features> _repository;
		public RemoveFeatureCommandHandler(IRepository<Domain.Entities.Features> repository)
		{
            _repository = repository;
		}

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
             
        }
    }
}

