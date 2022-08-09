using DTO.Apartment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.Apartment
{
    public class DeleteApartmentRequestValidator:AbstractValidator<DeleteApartmentRequest>
    {
        public DeleteApartmentRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);

        }
    }
}
