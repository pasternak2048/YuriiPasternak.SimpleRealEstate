using FluentValidation;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealty
{
    public class GetRealtyValidator : AbstractValidator<GetRealtyRequest>
    {
        public GetRealtyValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
