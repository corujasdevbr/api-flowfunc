using MediatR;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.CreateRule;

public sealed record CreateRuleRequest(string Name, string FunctionName, string RuleType) : IRequest<CreateRuleResponse>;
