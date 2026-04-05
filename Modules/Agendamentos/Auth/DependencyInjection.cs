using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Auth.Application.Interfaces;
using NexFlowSaude.Api.Modules.Auth.Application.Services;
using NexFlowSaude.Api.Modules.Auth.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Auth.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Auth;

public static class DependencyInjection
{
    public static IServiceCollection AddAuthModule(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthRepository, AuthRepository>();

        return services;
    }
}