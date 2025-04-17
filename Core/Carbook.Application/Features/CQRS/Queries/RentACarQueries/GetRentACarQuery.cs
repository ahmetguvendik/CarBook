using Carbook.Application.Features.CQRS.Results.RentACarResults;
using MediatR;

namespace Carbook.Application.Features.CQRS.Queries.RentACarQueries;

public class GetRentACarQuery : IRequest<List<GetRentACarQueryResult>>
{
    public string LocationID { get; set; }
    public bool Avaible { get; set; }
} 