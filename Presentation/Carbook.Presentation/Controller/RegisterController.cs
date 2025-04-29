using Carbook.Application.Features.CQRS.Commands.AppUserCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carbook.Presentation.Controller;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    private readonly IMediator _mediator;
    public RegisterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateAppUserCommand command)       
    {
        await _mediator.Send(command);
        return Ok("Eklendi");

    }
}