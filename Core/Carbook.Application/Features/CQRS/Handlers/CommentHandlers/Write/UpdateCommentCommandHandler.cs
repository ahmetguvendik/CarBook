using System;
using CarBook.Application.Features.Mediator.Commands.CommetCommands;
using CarBook.Application.Repositories.GenericRepository;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers.Write
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;
        public UpdateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var value = await _commentRepository.GetByIdAsync(request.Id);
            value.Name = request.Name;
            value.Description = request.Description;
            value.BlogId = request.BlogId;
            await _commentRepository.UpdateAsync(value);
            await _commentRepository.SaveChangesAsync();
        }
    }
}

