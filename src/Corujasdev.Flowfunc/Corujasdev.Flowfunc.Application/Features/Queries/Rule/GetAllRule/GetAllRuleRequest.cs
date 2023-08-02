using MediatR;

namespace Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetAllRule;
public sealed record GetAllRuleRequest : IRequest<GetAllRuleResponse>
{
    public int Page { get; set; } = 1;
    public int? Quantity { get; set; }
    public string? Name { get; set; }
    public String[]? Includes { get; set; }
}