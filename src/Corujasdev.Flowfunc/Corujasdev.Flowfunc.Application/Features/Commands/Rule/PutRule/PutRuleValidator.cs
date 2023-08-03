using FluentValidation;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.PutRule;

public sealed class PutRuleValidator : AbstractValidator<PutRuleRequest>
{
    public PutRuleValidator()
    {
        RuleFor(x => x.FunctionName).NotEmpty().WithMessage("Informe a {PropertyName}");
        RuleFor(x => x.FunctionName).MinimumLength(5).MaximumLength(32).WithMessage("O nome da Function deve ter entre 5 e 32 caracteres");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Informe a descrição da Function");
        RuleFor(x => x.RuleType).MaximumLength(2).WithMessage("O tipo de Function pode ter no máximo 2 caracteres");
    }
}
