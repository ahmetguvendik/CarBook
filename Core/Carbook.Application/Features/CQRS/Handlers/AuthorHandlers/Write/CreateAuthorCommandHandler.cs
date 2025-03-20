using System;
using CarBook.Application.Features.Mediator.Commands.AuthorCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandlers.Write
{
	public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
	{
        private readonly IRepository<Author> _repository;
		public CreateAuthorCommandHandler(IRepository<Author> repository)
		{
            _repository = repository;
		}

        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author();
            author.Id = Guid.NewGuid().ToString();
            author.Name = request.Name;
            author.ImageUrl = request.ImageUrl;
            author.Description = request.Description;
            await _repository.CreateAsync(author);
        }
    }
}

