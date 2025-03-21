using System;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Write
{
	public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
	{
        private readonly IRepository<Blog> _repository;
        
		public RemoveBlogCommandHandler(IRepository<Blog> repository)
		{
            _repository = repository;
		}

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAsync(blog);
        }
    }
}

