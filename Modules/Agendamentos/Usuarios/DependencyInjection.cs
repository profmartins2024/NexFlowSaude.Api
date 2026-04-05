using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Usuarios.Application.DTOs;
using NexFlowSaude.Api.Modules.Usuarios.Application.Interfaces;
using NexFlowSaude.Api.Modules.Usuarios.Application.Services;
using NexFlowSaude.Api.Modules.Usuarios.Application.Validators;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Usuarios.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Usuarios;

public static class DependencyInjection
{
    public static IServiceCollection AddUsuariosModule(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<ISenhaService, SenhaService>();

        // Repository
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        // Validators
        services.AddScoped<IValidator<UsuarioRequestDto>, UsuarioValidator>();

        return services;
    }
}