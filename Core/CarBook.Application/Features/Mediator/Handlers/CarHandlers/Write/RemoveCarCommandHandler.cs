using System;
using CarBook.Application.Features.Mediator.Commands.CarCommands;
using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers.Write
{
	public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand>
	{
        private readonly IRepository<Domain.Entities.Car> _repository;
        public RemoveCarCommandHandler(IRepository<Domain.Entities.Car> repository)
        {
            _repository = repository;
        }


        public async Task Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}

