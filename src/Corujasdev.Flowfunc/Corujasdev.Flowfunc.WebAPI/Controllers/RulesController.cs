using Corujasdev.Flowfunc.Application.Features.Commands.Rule.CreateRule;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Corujasdev.Flowfunc.WebAPI.Controllers
{
    [Route("api/[controller]")]
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
    }
}
