using FluentValidation;
using NexFlowSaude.Api.Modules.Usuarios.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Usuarios.Application.Validators;

public sealed class UsuarioValidator : AbstractValidator<UsuarioRequestDto>
{
    public UsuarioValidator()
    {
        RuleFor(x => x.NomeCompleto)
            .NotEmpty().WithMessage("O nome completo é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.")
            .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("O e-mail é obrigatório.")
            .EmailAddress().WithMessage("E-mail inválido.")
            .MaximumLength(150);

        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("O login é obrigatório.")
            .MinimumLength(4).WithMessage("O login deve ter no mínimo 4 caracteres.")
            .MaximumLength(50).WithMessage("O login deve ter no máximo 50 caracteres.")
            .Matches("^[a-zA-Z0-9._-]+$")
            .WithMessage("O login contém caracteres inválidos.");

        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(12).WithMessage("A senha deve ter no mínimo 12 caracteres.")
            .Matches("[A-Z]").WithMessage("A senha deve conter ao menos uma letra maiúscula.")
            .Matches("[a-z]").WithMessage("A senha deve conter ao menos uma letra minúscula.")
            .Matches("[0-9]").WithMessage("A senha deve conter ao menos um número.")
            .Matches("[^a-zA-Z0-9]").WithMessage("A senha deve conter ao menos um caractere especial.");

        RuleFor(x => x.ConfirmarSenha)
            .Equal(x => x.Senha)
            .WithMessage("As senhas não conferem.");

        RuleFor(x => x.Telefone)
            .MaximumLength(20)
            .When(x => !string.IsNullOrEmpty(x.Telefone));

        RuleFor(x => x.Cargo)
            .MaximumLength(100)
            .When(x => !string.IsNullOrEmpty(x.Cargo));
    }
}