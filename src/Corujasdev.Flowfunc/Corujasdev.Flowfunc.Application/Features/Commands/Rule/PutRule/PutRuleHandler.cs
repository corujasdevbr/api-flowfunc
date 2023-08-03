using AutoMapper;
using Corujasdev.Flowfunc.Application.Repositories;
using MediatR;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.PutRule;

public class PutRuleHandler : IRequestHandler<PutRuleRequest, PutRuleResponse>
{
    #region Properties
    private IRuleRepository _ruleRepository { get; }
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper { get; }

    #endregion

    #region Contructor
    public PutRuleHandler(IRuleRepository ruleRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _ruleRepository = ruleRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PutRuleResponse> Handle(PutRuleRequest request, CancellationToken cancellationToken)
    {
        var response = new PutRuleResponse();

        try
        {
            var exist = await _ruleRepository.GetById(request.Id, cancellationToken);

            if (exist is null)
            {
                response.AddNotification("Rule", "Id not found");
                response.StatusCode = 500;
                response.Message = "An error has occurred";
                response.Success = false;

                return response;
            }

            var existRule = _ruleRepository.Find(x => x.FunctionName == request.FunctionName && x.Id != request.Id);

            if (existRule!.Any())
            {
                response.AddNotification("Rule", "Rule registered");
                response.StatusCode = 500;
                response.Message = "An error has occurred";
                response.Success = false;

                return response;
            }

            var ruleUpdate = _mapper.Map(request, exist);
            var ruleResult = _ruleRepository.Update(ruleUpdate);
            await _unitOfWork.Save(cancellationToken);

            response.StatusCode = 200;
            response.Message = "Rule Updated";
            response.Data = new Result() { Id = request.Id, DateUpdated = ruleResult.DateUpdated!.Value };
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
    #endregion
}
