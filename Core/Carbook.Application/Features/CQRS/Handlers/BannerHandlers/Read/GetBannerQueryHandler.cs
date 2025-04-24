using Carbook.Application.Features.CQRS.Queries.Banner;
using Carbook.Application.Features.CQRS.Results.BannerResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.BannerHandlers.Read;

public class GetBannerQueryHandler : IRequestHandler<GetBannerQuery,List<GetBannerQueryResult>>
{
    private readonly IRepository<Banner> _repository;

    public GetBannerQueryHandler( IRepository<Banner> repository )
    {
              _repository = repository;
    }
    public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery request, CancellationToken cancellationToken)
    {
        var author = await _repository.GetAllAsync();
        return author.Select(x => new GetBannerQueryResult
        {
            Id = x.Id,
            VideoDescription = x.Description,
            Description = x.Description,
            VideoURL = x.VideoURL,
            Title = x.Title
            
        }).ToList();
    }
}