using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.CreateRealty;

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

        [HttpPost("Realty")]
        public async Task<ActionResult<CreateRealtyResponse>> Create([FromBody] CreateRealtyRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
