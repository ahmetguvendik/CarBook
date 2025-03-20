using Carbook.Application.Features.CQRS.Commands.BannerCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.BannerHandlers.Write;

public class RemoveBannerCommandHandler : IRequestHandler<RemoveBannerCommand>
{
    private readonly IRepository<Banner> _repository;

    public RemoveBannerCommandHandler( IRepository<Banner> repository)
    {
         _repository = repository;
    }
    public async Task Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetByIdAsync(request.Id);    
        await _repository.RemoveAsync(banner);
    }
}