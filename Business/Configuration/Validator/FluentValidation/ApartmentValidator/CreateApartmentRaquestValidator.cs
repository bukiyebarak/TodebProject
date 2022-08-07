using DTO.Apartment;
using FluentValidation;

namespace Business.Configuration.Validator.FluentValidation.ApartmentValidator
{
    public class CreateApartmentRaquestValidator: AbstractValidator<CreateApartmentRequest>
    {
        public CreateApartmentRaquestValidator()
        {
            RuleFor(x => x.Block).NotEmpty();
            RuleFor(x => x.ApartmentStatus).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Floor).NotEmpty();
            RuleFor(x => x.No).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
