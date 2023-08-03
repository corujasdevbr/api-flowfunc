using AutoMapper;
using Corujasdev.Flowfunc.Application.Repositories;
using MediatR;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.PostRule;

public sealed class PostRuleHandler : IRequestHandler<PostRuleRequest, PostRuleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRuleRepository _ruleRepository;
    private readonly IMapper _mapper;

    public PostRuleHandler(IUnitOfWork unitOfWork, IRuleRepository RuleRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _ruleRepository = RuleRepository;
        _mapper = mapper;
    }

    public async Task<PostRuleResponse> Handle(PostRuleRequest request, CancellationToken cancellationToken)
    {
        var response = new PostRuleResponse();

        try
        {
            var exist = _ruleRepository.Find(x => x.FunctionName == request.FunctionName);

            if (exist!.Any())
            {
                response.AddNotification("Rule", $"Rule {request.FunctionName} registered");
                response.StatusCode = 500;
                response.Message = "An error has occurred";
                response.Success = false;

                return response;
            }

            var rule = _mapper.Map<Domain.Entities.Rule>(request);
            _ruleRepository.Add(rule);
            await _unitOfWork.Save(cancellationToken);

            response.StatusCode = 201;
            response.Message = $"Rule {request.FunctionName} Created";
            response.Data = new Result() { Id = rule.Id, DateCreated = rule.DateCreated };
            response.Success = true;

            return response;
        }
        catch (Exception ex)
        {

            response.AddNotification("Error", ex.Message);
            response.StatusCode = 500;
            response.Message = "An error has occurred";
            response.Success = false;

            return response;
        }
    }
}