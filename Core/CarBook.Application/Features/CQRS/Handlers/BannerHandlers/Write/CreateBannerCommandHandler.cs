using Carbook.Application.Features.CQRS.Commands.BannerCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.BannerHandlers.Write;

public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
{
    private readonly IRepository<Banner> _repository;

    public CreateBannerCommandHandler( IRepository<Banner> repository)
    {
         _repository = repository;
    }
    public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = new Banner();
        banner.Id  = Guid.NewGuid().ToString();
        banner.Title = request.Title;
        banner.Description = request.Description;
        banner.VideoDescription = request.VideoDescription;
        banner.VideoURL = request.VideoURL;
        await _repository.CreateAsync(banner);
    }
}