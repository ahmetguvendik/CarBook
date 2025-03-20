using Carbook.Application.Features.CQRS.Results.BannerResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.Banner;

public class GetBannerQuery : IRequest<List<GetBannerQueryResult>>
{
    
}