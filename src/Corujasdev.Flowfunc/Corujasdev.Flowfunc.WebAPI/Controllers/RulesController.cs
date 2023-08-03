using Corujasdev.Flowfunc.Application.Features.Commands.Rule.CreateRule;
using Corujasdev.Flowfunc.Application.Features.Commands.Rule.DeleteRule;
using Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetAllRule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corujasdev.Flowfunc.WebAPI.Controllers
{
    [Route("api/rules")]
    [ApiController]
    public class RulesController : MainController
    {
        private readonly IMediator _mediator;

        public RulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<CreateRuleResponse>> Create(CreateRuleRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return CustomResponse(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllRuleRequest request,
          CancellationToken cancelationToken
        )
        {
            var result = await _mediator.Send(request, cancelationToken);

            return CustomResponse(result);
        }
    }
}
