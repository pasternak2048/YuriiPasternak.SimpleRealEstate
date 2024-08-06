using FluentValidation;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.GetRealties
{
    public class GetRealtiesValidator : AbstractValidator<GetRealtiesRequest>
    {
        public GetRealtiesValidator() {
            RuleFor(x => x.UserParams.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageNumber has to be grearer or equal to 1.");

            RuleFor(x => x.UserParams.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize has to be grearer or equal to 1.");
        }
    }
}
