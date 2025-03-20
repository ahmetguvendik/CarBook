using System;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using Carbook.Application.Repositories;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Write
{
	public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
	{
        private readonly IRepository<Domain.Entities.Author> _repository;
        public RemoveAuthorCommandHandler(IRepository<Domain.Entities.Author> repository)
        {
            _repository = repository;
        }


        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(value);
        }
    }
}

