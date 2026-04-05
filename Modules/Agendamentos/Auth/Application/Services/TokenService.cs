using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NexFlowSaude.Api.Modules.Auth.Application.Interfaces;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Auth.Application.Services;

public sealed class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GerarAccessToken(Usuario usuario)
    {
        if (usuario is null)
            throw new ArgumentNullException(nameof(usuario));

        var jwtSettings = _configuration.GetSection("JwtSettings");

        var secretKey = jwtSettings["SecretKey"]
            ?? throw new InvalidOperationException("JwtSettings:SecretKey não configurado.");

        var issuer = jwtSettings["Issuer"]
            ?? throw new InvalidOperationException("JwtSettings:Issuer não configurado.");

        var audience = jwtSettings["Audience"]
            ?? throw new InvalidOperationException("JwtSettings:Audience não configurado.");

        var expirationMinutesText = jwtSettings["ExpirationMinutes"];
        var expirationMinutes = int.TryParse(expirationMinutesText, out var minutos) ? minutos : 15;

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, usuario.Login ?? string.Empty),
            new(JwtRegisteredClaimNames.Email, usuario.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new("nome", usuario.NomeCompleto ?? string.Empty),
            new("login", usuario.Login ?? string.Empty)
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GerarRefreshToken()
    {
        var randomBytes = new byte[64];

        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);

        return Convert.ToBase64String(randomBytes);
    }
}