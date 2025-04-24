using Carbook.Application.Features.CQRS.Commands.ReservationCommands;
using Carbook.Application.Features.CQRS.Queries.ReservationQueries;
using Carbook.Application.Features.CQRS.Results.ReservationResults;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Carbook.Presentation.Controller;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReservationController( IMediator mediator)
    {
         _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var value = await _mediator.Send(new GetReservationQuery());
        return Ok(value);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult>Get(string id)
    {
        var value = await _mediator.Send(new GetReserationByIdQuery(id));
        return Ok(value);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateReservationCommand command)
    {
        await _mediator.Send(command);
        return Ok("EKlendi");
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateReservationCommand command)
    {
        await _mediator.Send(command);
        return Ok("Guncellendi");
    }
}