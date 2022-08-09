using DTO.Bill;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.Bill
{
    public class UpdateBillRequestValidator:AbstractValidator<UpdateBillRequest>
    {
        public UpdateBillRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty();
            RuleFor(x => x.UserId).GreaterThan(0).NotEmpty();
            RuleFor(x => x.Electricity).GreaterThan(0).NotEmpty();
            RuleFor(x => x.Water).GreaterThan(0).NotEmpty();
            RuleFor(x => x.NaturalGas).GreaterThan(0).NotEmpty();
            RuleFor(x => x.Dues).GreaterThan(0).NotEmpty();
        }
    }
}
