using AutoMapper;
using Corujasdev.Flowfunc.Application.Dto;
using Corujasdev.Flowfunc.Application.Repositories;
using MediatR;
using System.Net;

namespace Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetRuleById
{
    public class GetRuleByIdHandler : IRequestHandler<GetRuleByIdRequest, GetRuleByIdResponse>
    {
        #region Properties
        private IRuleRepository _ruleRepository { get; }
        private IMapper _mapper;

        #endregion

        #region Contructor
        public GetRuleByIdHandler(IRuleRepository ruleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ruleRepository = ruleRepository;
        }
        #endregion

        public async Task<GetRuleByIdResponse> Handle(GetRuleByIdRequest request, CancellationToken cancellationToken)
        {
            var response = new GetRuleByIdResponse();

            try
            {
                var rule = await _ruleRepository.GetById(request.Id, cancellationToken, request.Includes);

                if (rule is null)
                {
                    response.Data = _mapper.Map<RuleDto>(rule);
                    response.StatusCode = (int)HttpStatusCode.OK;
                    response.Success = true;
                    response.Message = "Success";

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
    }
}
