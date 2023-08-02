using FluentValidation;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.CreateRule;

public sealed class CreateRuleValidator : AbstractValidator<CreateRuleRequest>
{
    public CreateRuleValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255).WithMessage("Please ensure you have entered your {PropertyName}"); ;
        RuleFor(x => x.FunctionName).NotEmpty().MinimumLength(5).MaximumLength(32).WithMessage("Please ensure you have entered your {PropertyName}");
    }
}