using AutoMapper;


namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.PostRule
{
    public sealed class PostRuleMapper : Profile
    {
        public PostRuleMapper()
        {
            CreateMap<PostRuleRequest, Domain.Entities.Rule>().ReverseMap();
        }
    }
}
