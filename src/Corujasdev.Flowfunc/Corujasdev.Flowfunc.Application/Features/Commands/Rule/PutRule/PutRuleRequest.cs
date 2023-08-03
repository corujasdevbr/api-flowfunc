using MediatR;
using System.Text.Json.Serialization;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.PutRule;

public sealed record PutRuleRequest : IRequest<PutRuleResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public string? FunctionName { get; set; }
    public string? RuleType { get; set; }
}
