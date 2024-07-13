using System;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers.Write
{
	public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
	{
        private readonly IRepository<Domain.Entities.Features> _repository;
		public CreateFeatureCommandHandler(IRepository<Domain.Entities.Features> repository)
		{
            _repository = repository;
		}

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var feature = new Domain.Entities.Features();
            feature.Id = Guid.NewGuid().ToString();
            feature.Name = request.Name;
            await _repository.CreateAsync(feature);
        }
    }
}

