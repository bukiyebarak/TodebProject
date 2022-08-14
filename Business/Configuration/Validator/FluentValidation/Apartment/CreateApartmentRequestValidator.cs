using DTO.Apartment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.Apartment
{
    //Apartman ekleme sırasında zorunlu olarak girilmesi gereken yerler Validation ile eklendi.
    public class CreateApartmentRequestValidator:AbstractValidator<CreateApartmentRequest>
    {
        public CreateApartmentRequestValidator()
        {
            RuleFor(x => x.Block).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Floor).NotEmpty();
            RuleFor(x => x.No).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
