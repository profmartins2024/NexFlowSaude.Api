using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NexFlowSaude.Api.Modules.Agendamentos;
using NexFlowSaude.Api.Modules.Auth;
using NexFlowSaude.Api.Modules.Chat;
using NexFlowSaude.Api.Modules.Chat.Infrastructure.Hubs;
using NexFlowSaude.Api.Modules.Estoque;
using NexFlowSaude.Api.Modules.Faturamento;
using NexFlowSaude.Api.Modules.Financeiro;
using NexFlowSaude.Api.Modules.Ia;
using NexFlowSaude.Api.Modules.Notificacoes;
using NexFlowSaude.Api.Modules.Pacientes;
using NexFlowSaude.Api.Modules.Relatorios;
using NexFlowSaude.Api.Modules.Usuarios;
using NexFlowSaude.Api.Shared.Extensions;
using NexFlowSaude.Api.Shared.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddNexFlowDatabase(builder.Configuration);
builder.Services.AddSharedServices(builder.Configuration);

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"]
    ?? throw new InvalidOperationException("JwtSettings:SecretKey não configurado.");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddAgendamentosModule();
builder.Services.AddAuthModule();
builder.Services.AddEstoqueModule();
builder.Services.AddFaturamentoModule();
builder.Services.AddFinanceiroModule();
builder.Services.AddPacientesModule();
builder.Services.AddRelatoriosModule();
builder.Services.AddUsuariosModule();
builder.Services.AddIaModule();
builder.Services.AddNotificacoesModule();
builder.Services.AddChatModule();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/hubs/chat");

app.Run();