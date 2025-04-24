using Carbook.Application.Features.CQRS.Commands.AboutCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.AboutHandlers.Write;

public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
{
    private readonly IRepository<About>  _repository;

    public UpdateAboutCommandHandler( IRepository<About> repository)
    {
         _repository = repository;
    }
    public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        value.Description = request.Description;
        value.ImageURL = request.ImageURL;
        value.Title = request.Title;
        await _repository.UpdateAsync(value);
    }
}