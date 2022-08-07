using DTO.Apartment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.ApartmentValidator
{
    public class UpdateApartmentRequestValidator : AbstractValidator<UpdateApartmentRequest>
    {
        public UpdateApartmentRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.ApartmentStatus).NotEmpty().WithMessage("Daire durumu boş geçilemez");
            RuleFor(x => x.Block).NotEmpty().WithMessage("Daire blok adı boş geçilemez");
            RuleFor(x => x.Floor).NotEmpty().WithMessage("Dairenin bulunduğu kat boş geçilemez");
            RuleFor(x => x.No).NotEmpty().WithMessage("Daire numarası boş geçilemez");
            RuleFor(x => x.Type).NotEmpty();
        }
    }
}
