using MediatR;

namespace Carbook.Application.Features.CQRS.Commands.AppUserCommands;

public class CreateAppUserCommand : IRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    
}