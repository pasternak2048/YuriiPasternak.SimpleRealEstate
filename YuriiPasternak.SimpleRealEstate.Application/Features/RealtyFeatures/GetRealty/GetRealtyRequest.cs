using MediatR;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealty
{
    public class GetRealtyRequest : IRequest<GetRealtyResponse>
    {
        public Guid Id { get; set; }
    }
}
