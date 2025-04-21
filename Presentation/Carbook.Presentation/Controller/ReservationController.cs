using Carbook.Application.Features.CQRS.Commands.ReservationCommands;
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
    // POST api/values
    [HttpPost]
    public async Task<IActionResult> Post(CreateReservationCommand command)
    {
        await _mediator.Send(command);
        return Ok("EKlendi");
    }
}