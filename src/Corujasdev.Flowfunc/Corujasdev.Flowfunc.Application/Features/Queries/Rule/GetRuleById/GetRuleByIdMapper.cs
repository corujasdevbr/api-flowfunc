using AutoMapper;
using Corujasdev.Flowfunc.Application.Dto;

namespace Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetRuleById
{
    public class GetRuleByIdMapper : Profile
    {
        public GetRuleByIdMapper()
        {
            CreateMap<RuleDto, GetRuleByIdResponse>().ReverseMap();
            CreateMap<RuleDto, Domain.Entities.Rule>().ReverseMap();
        }
    }
}
