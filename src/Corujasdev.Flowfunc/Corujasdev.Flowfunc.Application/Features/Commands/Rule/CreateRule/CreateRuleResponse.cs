using Corujasdev.Flowfunc.Application.Common.Core;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.CreateRule
{
    public class CreateRuleResponse : GenericResult
    {
        public new Result? Data { get; set; }
    }

    public class Result
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
