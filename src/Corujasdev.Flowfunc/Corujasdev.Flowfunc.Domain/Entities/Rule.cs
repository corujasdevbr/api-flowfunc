using Corujasdev.Flowfunc.Domain.Common;

namespace Corujasdev.Flowfunc.Domain.Entities;
public class Rule : BaseEntity
{
    public string? Name { get; set; }
    public string? FunctionName { get; set; }
    public string? RuleType { get; set; }
}