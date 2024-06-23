using System;
using CarBook.Application.Features.Mediator.Commands.CommetCommands;
using CarBook.Application.Repositories.GenericRepository;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Write
{
	public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>
	{
        private readonly ICommentRepository _commentRepository;
		public CreateCommentCommandHandler(ICommentRepository commentRepository)
		{
            _commentRepository = commentRepository;
		}

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment();
            comment.Id = Guid.NewGuid().ToString();
            comment.Name = request.Name;
            comment.Description = request.Description;
            comment.CreatedTime = DateTime.UtcNow;
            comment.BlogId = request.BlogId;
            await _commentRepository.CreateAsync(comment);
            await _commentRepository.SaveChangesAsync();
        }
    }
}

