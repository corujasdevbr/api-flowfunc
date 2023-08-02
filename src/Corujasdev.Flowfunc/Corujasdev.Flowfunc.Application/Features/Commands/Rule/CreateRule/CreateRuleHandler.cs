using AutoMapper;
using Corujasdev.Flowfunc.Application.Repositories;
using MediatR;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.CreateRule;

public sealed class CreateRuleHandler : IRequestHandler<CreateRuleRequest, CreateRuleResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRuleRepository _ruleRepository;
    private readonly IMapper _mapper;

    public CreateRuleHandler(IUnitOfWork unitOfWork, IRuleRepository RuleRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _ruleRepository = RuleRepository;
        _mapper = mapper;
    }

    public async Task<CreateRuleResponse> Handle(CreateRuleRequest request, CancellationToken cancellationToken)
    {
        var response = new CreateRuleResponse();

        try
        {
            var exist = _ruleRepository.Find(x => x.FunctionName == request.Name);

            if (exist!.Any())
            {
                response.AddNotification("Rule", $"Rule {request.Name} registered");
                response.StatusCode = 500;
                response.Message = "An error has occurred";
                response.Success = false;

                return response;
            }

            var rule = _mapper.Map<Domain.Entities.Rule>(request);
            _ruleRepository.Add(rule);
            await _unitOfWork.Save(cancellationToken);

            response.StatusCode = 201;
            response.Message = $"Rule {request.Name} Created";
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