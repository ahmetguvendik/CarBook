using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carbook.Application;

public static class ServiceRegistration
{
    public static void AddApplicationService(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly)); 
    }


}