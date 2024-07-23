using FluentValidation;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.UpdateRealty
{
    public class UpdateRealtyValidator : AbstractValidator<UpdateRealtyRequest>
    {
        public UpdateRealtyValidator()
        {
            RuleFor(x => x.Body.Description).NotEmpty().WithMessage("Description mustn`t be empty.");

            RuleFor(x => x.Body.Description)
                .MinimumLength(10)
                .MaximumLength(254)
                .WithMessage("Description length has to be  less than 255 and bigger than 10.");

            RuleFor(x => x.Body.LocationId).NotEmpty().WithMessage("LocationId mustn`t be empty.");

            RuleFor(x => x.Body.RealtyTypeId)
                .NotNull().WithMessage("Realty Type Id mustn't be null");

            RuleFor(x => x.Body.RealtyTypeId).IsInEnum().WithMessage("Realty Type Id: out of range.");
        }
    }
}
