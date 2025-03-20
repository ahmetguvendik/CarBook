using System;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Write
{
	public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;
		public UpdateBlogCommandHandler(IRepository<Blog> repository)
		{
            _repository = repository;
		}

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);
            blog.Title = request.Title;
            blog.CreatedTime = request.CreatedTime;
            blog.CoverImageUrl = request.CoverImageUrl;
            blog.CategoryId = request.CategoryId;
            blog.AuthorId = request.AuthorId;
            await _repository.UpdateAsync(blog);
        }
    }
}

