using Carbook.Application.Features.CQRS.Commands.BannerCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.BannerHandlers.Write;

public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
{
    private readonly IRepository<Banner> _repository;

    public UpdateBannerCommandHandler( IRepository<Banner> repository)
    {
         _repository = repository;
    }
    public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetByIdAsync(request.Id);
        banner.Description = request.Description;
        banner.Title = request.Title;
        banner.VideoDescription = request.VideoDescription;
        banner.VideoURL = request.VideoURL;
        await _repository.UpdateAsync(banner);
    }
}