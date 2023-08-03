using Corujasdev.Flowfunc.Application.Common.Core;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.PutRule;

public class PutRuleResponse : GenericResult
{
    public new Result? Data { get; set; }
}

public class Result
{
    public Guid Id { get; set; }
    public DateTime DateUpdated { get; set; }
}
