using DTO.Bill;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.Bill
{
    public class DeleteBillRequestValidator:AbstractValidator<DeleteBillRequest>
    {
        public DeleteBillRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty();
        }
    }
}
