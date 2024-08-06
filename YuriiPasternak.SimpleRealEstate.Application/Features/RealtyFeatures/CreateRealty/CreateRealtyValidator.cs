using FluentValidation;

namespace YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.CreateRealty
{
    public sealed class CreateRealtyValidator : AbstractValidator<CreateRealtyRequest>
    {
        public CreateRealtyValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description mustn`t be empty.");

            RuleFor(x => x.Description)
                .MinimumLength(10)
                .MaximumLength(254)
                .WithMessage("Description length has to be  less than 255 and bigger than 10.");

            RuleFor(x => x.LocationId).NotEmpty().WithMessage("LocationId mustn`t be empty.");

            RuleFor(x => x.RealtyTypeId)
                .NotNull().WithMessage("Realty Type Id mustn't be null");

            RuleFor(x => x.RealtyTypeId).IsInEnum().WithMessage("Realty Type Id: out of range.");
        }
    }
}
