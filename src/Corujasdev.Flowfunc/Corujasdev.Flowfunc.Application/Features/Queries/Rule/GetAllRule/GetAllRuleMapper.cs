using AutoMapper;
using Corujasdev.Flowfunc.Application.Dto;

namespace Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetAllRule;

public sealed class GetAllRuleMapper : Profile
{
    public GetAllRuleMapper()
    {
        CreateMap<RuleDto, GetAllRuleResponse>().ReverseMap();
        CreateMap<RuleDto, Domain.Entities.Rule>().ReverseMap();
    }
}
