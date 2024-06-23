using System;
using CarBook.Application.Features.Mediator.Commands.CommetCommands;
using CarBook.Application.Repositories.GenericRepository;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Write
{
	public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand>
	{
        private readonly ICommentRepository _commentRepository;
		public RemoveCommentCommandHandler(ICommentRepository commentRepository)
		{
            _commentRepository = commentRepository;
		}

        public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _commentRepository.GetByIdAsync(request.Id);
            await _commentRepository.RemoveAsync(value);
            await _commentRepository.SaveChangesAsync();
        }
    }
}

