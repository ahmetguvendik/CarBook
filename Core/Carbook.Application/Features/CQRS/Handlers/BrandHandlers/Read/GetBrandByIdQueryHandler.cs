using Carbook.Application.Features.CQRS.Queries.BrandQueries;
using Carbook.Application.Features.CQRS.Results.BrandResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.BrandHandlers.Read;

public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery,GetBrandByIdQueryResult>
{
    private readonly IRepository<Brand> _repository;

    public GetBrandByIdQueryHandler( IRepository<Brand> repository)
    {
         _repository = repository;
    }
    public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetBrandByIdQueryResult()
        {
            Id = value.Id,
            Name = value.Name,
        };
    }
}