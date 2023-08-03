using Corujasdev.Flowfunc.Application.Features.Commands.Rule.PostRule;
using Corujasdev.Flowfunc.Application.Features.Commands.Rule.DeleteRule;
using Corujasdev.Flowfunc.Application.Features.Commands.Rule.PutRule;
using Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetAllRule;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Corujasdev.Flowfunc.Application.Features.Queries.Rule.GetRuleById;

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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllRuleRequest request,
          CancellationToken cancelationToken
        )
        {
            var result = await _mediator.Send(request, cancelationToken);

            return CustomResponse(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id,
          CancellationToken cancelationToken
        )
        {
            var request = new GetRuleByIdRequest(id);

            var result = await _mediator.Send(request, cancelationToken);

            return CustomResponse(result);
        }

        [HttpPost]
        public async Task<ActionResult<PostRuleResponse>> Create(PostRuleRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return CustomResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancelationToken)
        {
            var request = new DeleteRuleRequest(id);
            
            var result = await _mediator.Send(request, cancelationToken);

            return CustomResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PutRuleRequest request, CancellationToken cancelationToken)
        {
            request.Id = id;

            var result = await _mediator.Send(request, cancelationToken);

            return CustomResponse(result);
        }
    }
}
