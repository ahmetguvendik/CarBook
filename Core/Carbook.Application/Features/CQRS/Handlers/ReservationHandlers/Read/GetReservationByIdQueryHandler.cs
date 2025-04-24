using Carbook.Application.Features.CQRS.Queries.ReservationQueries;
using Carbook.Application.Features.CQRS.Results.ReservationResults;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.ReservationHandlers.Read;

public class GetReservationByIdQueryHandler : IRequestHandler<GetReserationByIdQuery,GetReservationByIdQueryResult>
{
    private readonly IRepository<Reservation> _repository;

    public GetReservationByIdQueryHandler(IRepository<Reservation> repository)
    {
        _repository = repository;
    }
    public async Task<GetReservationByIdQueryResult> Handle(GetReserationByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return new GetReservationByIdQueryResult()
        {
            Id = value.Id,
            Email = value.Email,
            Statues = value.Statues,
            
        };
    }
}