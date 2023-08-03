using Canducci.Pagination;
using Corujasdev.Flowfunc.Application.Common.Core;
using Corujasdev.Flowfunc.Application.Dto;

namespace Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetAllRule
{
    public class GetAllRuleResponse : GenericResult
    {
        public new PaginatedRest<RuleDto>? Data { get; set; }
    }
}
