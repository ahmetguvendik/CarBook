using Carbook.Application.Features.CQRS.Commands.AboutCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.AboutHandlers.Write;

public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
{
    private readonly IRepository<About> _repository;

    public CreateAboutCommandHandler( IRepository<About> repository)
    {
         _repository = repository;    
    }
    public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
    {
        var about = new About();
        about.Id = Guid.NewGuid().ToString();
        about.Description = request.Description;
        about.ImageURL = request.ImageURL;
        about.Title = request.Title;
        await _repository.CreateAsync(about);
    }
}