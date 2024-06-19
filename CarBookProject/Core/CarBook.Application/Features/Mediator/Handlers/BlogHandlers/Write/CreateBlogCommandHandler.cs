using System;
using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers.Write
{
	public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
	{
        private readonly IRepository<Blog> _repository;
		public CreateBlogCommandHandler(IRepository<Blog> repository)
		{
            _repository = repository;
		}

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog();
            blog.Id = Guid.NewGuid().ToString();
            blog.Title = request.Title;
            blog.CreatedTime = DateTime.Now;
            blog.CoverImageUrl = request.CoverImageUrl;
            blog.CategoryId = request.CategoryId;
            blog.AuthorId = request.AuthorId;
            await _repository.CreateAsync(blog);
        }
    }
}

