using MediatR;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.DeleteRule
{
    public sealed record DeleteRuleRequest(Guid Id) : IRequest<DeleteRuleResponse>;
}
