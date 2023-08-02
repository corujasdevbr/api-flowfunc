using Corujasdev.Flowfunc.Domain.Common;

namespace Corujasdev.Flowfunc.Domain.Entities;
public class Rule : BaseEntity
{
    public required string FunctionName { get; set; }
    public required string Description { get; set; }
    public string? RuleType { get; set; }
}