using AutoMapper;


namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.CreateRule
{
    public sealed class CreateRuleMapper : Profile
    {
        public CreateRuleMapper()
        {
            CreateMap<CreateRuleRequest, Domain.Entities.Rule>().ReverseMap();
        }
    }
}
