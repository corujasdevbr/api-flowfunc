using MediatR;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.PostRule;

public sealed record PostRuleRequest(string FunctionName, string Description, string RuleType) : IRequest<PostRuleResponse>;
