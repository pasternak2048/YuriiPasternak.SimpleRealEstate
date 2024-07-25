using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.CreateRealty;
using YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.DeleteRealty;
using YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.UpdateRealty;
using static YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.UpdateRealty.UpdateRealtyRequest;

namespace YuriiPasternak.SimpleRealEstate.WebAPI.Controllers
{
    [Authorize]
    public class RealtyController : BaseApiController
    {
        private readonly IMediator _mediator;

        public RealtyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateRealtyRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> Update (Guid id, [FromBody] UpdateRealtyRequestBody requestBody, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new UpdateRealtyRequest() { Id = id, Body = requestBody }, cancellationToken);
            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> Delete (Guid id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new DeleteRealtyRequest() { Id = id }, cancellationToken);
            return Ok(response);
        }
    }
}