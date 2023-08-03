using AutoMapper;
using Corujasdev.Flowfunc.Application.Repositories;
using MediatR;

namespace Corujasdev.Flowfunc.Application.Features.Commands.Rule.DeleteRule
{
    public class DeleteRuleHandler : IRequestHandler<DeleteRuleRequest, DeleteRuleResponse>
    {
        #region Properties
        private readonly IRuleRepository _ruleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Contructor
        public DeleteRuleHandler(IRuleRepository ruleRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _ruleRepository = ruleRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteRuleResponse> Handle(DeleteRuleRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteRuleResponse();

            try
            {
                var rule = await _ruleRepository.GetById(request.Id, cancellationToken);

                if (rule is not null)
                {
                    rule.Deleted();
                    _ruleRepository.Update(rule);
                    await _unitOfWork.Save(cancellationToken);

                    response.StatusCode = 200;
                    response.Message = "Rule Deleted";
                    response.Data = new Result() { Id = rule.Id, DateDeleted = DateTime.UtcNow };
                    response.Success = true;

                    return response;
                }

                response.AddNotification("Rule", "Id not found");
                response.StatusCode = 500;
                response.Message = "An error has occurred";
                response.Success = false;

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
}
