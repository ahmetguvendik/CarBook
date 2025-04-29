using Carbook.Application.Features.CQRS.Queries.AppUserQueries;
using Carbook.Application.Features.CQRS.Results.AppUserResult;
using Carbook.Application.Repositories;
using Carbook.Application.Repositories.AppRoleRepositories;
using Carbook.Application.Repositories.AppUserRepositories;
using CarBook.Domain.Entities;
using MediatR;

namespace Carbook.Application.Features.CQRS.Handlers.AppUserHandlers.Read;

public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
{
   private readonly IAppUserRepository _appUserRepository;
   private readonly IAppRoleRepository _appRoleRepository;

   public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository, IAppRoleRepository appRoleRepository)
   {
        _appUserRepository = appUserRepository;
        _appRoleRepository = appRoleRepository;
   }
    
    public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
    {
        var values = new GetCheckAppUserQueryResult();
        var user = await _appUserRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password); 
        if (user == null)
        {
            values.IsExist = false;
        }
        else
        {
            values.IsExist = true;
            values.Username  = user.Username;
            values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId))?.AppRoleName;
            values.Id = user.Id;
        }
        return values;
    }
}