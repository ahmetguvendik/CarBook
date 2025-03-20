using Carbook.Application.Features.CQRS.Results.BannerResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.Banner;

public class GetBannerByIdQuery : IRequest<GetBannerByIdQueryResult>
{
    public string Id { get; set; }

    public GetBannerByIdQuery(string id)
    {
         Id = id;
    }
}