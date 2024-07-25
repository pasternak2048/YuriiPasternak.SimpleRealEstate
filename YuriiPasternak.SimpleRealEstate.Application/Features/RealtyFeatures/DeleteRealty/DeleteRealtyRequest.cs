using MediatR;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.DeleteRealty
{
    public class DeleteRealtyRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
