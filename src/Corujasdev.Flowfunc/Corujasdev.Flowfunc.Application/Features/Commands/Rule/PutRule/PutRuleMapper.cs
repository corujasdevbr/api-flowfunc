using AutoMapper;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.PutRule;

public sealed class PutRuleMapper : Profile
{
    public PutRuleMapper()
    {
        CreateMap<PutRuleRequest, Domain.Entities.Rule>().ReverseMap();
    }
}
