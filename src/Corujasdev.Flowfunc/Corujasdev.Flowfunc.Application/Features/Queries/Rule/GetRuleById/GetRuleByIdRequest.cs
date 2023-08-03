using MediatR;

namespace Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetRuleById
{
    public sealed record GetRuleByIdRequest(Guid Id, string[]? Includes = null) : IRequest<GetRuleByIdResponse>;
}
