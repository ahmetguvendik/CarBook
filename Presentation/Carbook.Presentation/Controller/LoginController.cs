using Carbook.Application.Features.CQRS.Queries.AppUserQueries;
using Carbook.Application.Tools;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carbook.Presentation.Controller;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;
    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login(GetCheckAppUserQuery query)
    {
        var value = await _mediator.Send(query);
        if (value.IsExist)
        {
            return Ok(JwtTokenGenerator.GenerateJwtTokenDefault(value));
        }
        return BadRequest("Email or password is incorrect");
    }
    
}