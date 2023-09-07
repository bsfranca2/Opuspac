using Opuspac.Core.Services.Implementations;
using Opuspac.Core.Services;
using Opuspac.Api.Services;

namespace Opuspac.Api.Utilities;

public static class ServiceCollectionExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddSingleton<IPrintJobService, PrintJobService>();
        services.AddSingleton<ISecurityService, SecurityService>();
        services.AddSingleton<ITokenService, TokenService>();
        services.AddSingleton<IUserService, UserService>();
    }
}
