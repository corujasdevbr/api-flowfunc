using Corujasdev.Flowfunc.Application.Common.Core;
using Corujasdev.Flowfunc.Application.Dto;

namespace Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetRuleById
{
    public class GetRuleByIdResponse : GenericResult
    {
        public new RuleDto? Data { get; set; }
    }
}
