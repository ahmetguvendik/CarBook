using Carbook.Application.Features.CQRS.Queries.Banner;
using Carbook.Application.Features.CQRS.Results.BannerResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.BannerHandlers.Read;

public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery,GetBannerByIdQueryResult>
{
    private readonly IRepository<Banner> _repository;

    public GetBannerByIdQueryHandler( IRepository<Banner> repository )
    {
         _repository = repository;
    }
    public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetBannerByIdQueryResult()
        {
            Description = value.Description,
            Id = value.Id,
            VideoDescription = value.VideoDescription,
            VideoURL = value.VideoURL,
            
        };
    }
}