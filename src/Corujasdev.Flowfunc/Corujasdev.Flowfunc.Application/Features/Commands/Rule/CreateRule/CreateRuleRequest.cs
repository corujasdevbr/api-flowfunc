using MediatR;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.CreateRule;

public sealed record CreateRuleRequest(string FunctionName, string Description, string RuleType) : IRequest<CreateRuleResponse>;
