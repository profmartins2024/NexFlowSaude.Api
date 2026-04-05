using System.Net;
using System.Text.Json;
using FluentValidation;

namespace NexFlowSaude.Api.Shared.Middleware;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro não tratado");

            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var statusCode = HttpStatusCode.InternalServerError;
        object response;

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;

                response = new
                {
                    sucesso = false,
                    mensagem = "Erro de validação.",
                    erros = validationException.Errors.Select(e => e.ErrorMessage)
                };
                break;

            case InvalidOperationException invalidOperationException:
                statusCode = HttpStatusCode.BadRequest;

                response = new
                {
                    sucesso = false,
                    mensagem = invalidOperationException.Message
                };
                break;

            case KeyNotFoundException keyNotFoundException:
                statusCode = HttpStatusCode.NotFound;

                response = new
                {
                    sucesso = false,
                    mensagem = keyNotFoundException.Message
                };
                break;

            case UnauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized;

                response = new
                {
                    sucesso = false,
                    mensagem = "Acesso não autorizado."
                };
                break;

            default:
                response = new
                {
                    sucesso = false,
                    mensagem = "Erro interno no servidor."
                };
                break;
        }

        context.Response.StatusCode = (int)statusCode;

        var json = JsonSerializer.Serialize(response);

        return context.Response.WriteAsync(json);
    }
}