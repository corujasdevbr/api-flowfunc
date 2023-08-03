using Corujasdev.Flowfunc.Application.Common.Core;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.DeleteRule;
public class DeleteRuleResponse : GenericResult
{
    public new Result? Data { get; set; }
}
public class Result
{
    public Guid Id { get; set; }
    public DateTime DateDeleted { get; set; }
}
