using Carbook.Application.Enums;
using Carbook.Application.Features.CQRS.Commands.AppUserCommands;
using Carbook.Application.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.AppUserHandlers.Write;

public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand>
{
    private readonly IRepository<AppUser> _repository;

    public CreateAppUserCommandHandler(IRepository<AppUser> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
    {
         await _repository.CreateAsync(new AppUser()    
        {
            Id = Guid.NewGuid().ToString(),
            Username = request.Username,
            Password = request.Password,
            Email = request.Email,
            Name = request.Name,
            Surname = request.Surname,
            AppRoleId = "2",
        });
        await _repository.SaveChangesAsync();
    }
}