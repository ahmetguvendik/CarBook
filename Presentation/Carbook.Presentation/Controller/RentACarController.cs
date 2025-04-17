using Carbook.Application.Features.CQRS.Queries.RentACarQueries;
using Carbook.Application.Features.CQRS.Results.RentACarResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carbook.Presentation.Controller;

[Route("api/[controller]")]
[ApiController]
public class RentACarController : ControllerBase
{
    private readonly IMediator _mediator;

    public RentACarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Get(GetRentACarQuery query)
    {
        var value = await _mediator.Send(query);
        return Ok(value);
    }


   
} 