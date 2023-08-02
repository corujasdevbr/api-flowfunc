using AutoMapper;
using Canducci.Pagination;
using Corujasdev.Flowfunc.Application.Dto;
using Corujasdev.Flowfunc.Application.Repositories;
using Corujasdev.Flowfunc.Domain.Common;
using MediatR;
using System.Net;

namespace Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetAllRule;

public class GetAllRuleHandler : IRequestHandler<GetAllRuleRequest, GetAllRuleResponse>
{
    private readonly IRuleRepository _ruleRepository;
    private readonly IMapper _mapper;

    public GetAllRuleHandler(IRuleRepository ruleRepository, IMapper mapper)
    {
        _ruleRepository = ruleRepository;
        _mapper = mapper;
    }

    public async Task<GetAllRuleResponse> Handle(GetAllRuleRequest request, CancellationToken cancellationToken)
    {
        var response = new GetAllRuleResponse();

        try
        {
            var rules = request.Active ? _ruleRepository.GetAll(request.Includes)!.Active() : _ruleRepository.GetAll(request.Includes)!;

            if (!string.IsNullOrEmpty(request.Name))
                rules = rules.Where(x => x.Name!.ToLower().Contains(request.Name.ToLower())).AsQueryable();

            var rulesDistinct = rules.GroupBy(q => q.Name).Select(x => x.First()).ToList();

            var rulesPagination = _mapper.Map<IEnumerable<RuleDto>>(rulesDistinct.Distinct()).ToPaginatedRest(request.Page, request.Quantity ?? rules.Count() );

            response.Data = rulesPagination;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.Success = true;
            response.Message = "Success";

            return await Task.FromResult(response);
        }
        catch (Exception ex)
        {
            response.AddNotification("Error", ex.Message);
            response.StatusCode = 500;
            response.Message = "An error has occurred";
            response.Success = false;

            return await Task.FromResult(response);
        }
    }
}
