using System;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers.Write
{
	public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>  
	{
        private readonly IRepository<Domain.Entities.Features> _repository;

		public UpdateFeatureCommandHandler(IRepository<Domain.Entities.Features> repository)
		{
            _repository = repository;
		}

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = await _repository.GetByIdAsync(request.Id);
            feature.Name = request.Name;
            await _repository.UpdateAsync(feature);
        }
    }
}

