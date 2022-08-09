using DTO.Bill;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.Bill
{
    //Fatura ekleme sırasında gerekli olan koşullar CreateBillRequestValidator sınıfına constructor sınıfı ile verildi.CreateBillRequest sınıfı DTO katmanında oluşturuldu.
    public class CreateBillRequestValidator:AbstractValidator<CreateBillRequest>
    {
        public CreateBillRequestValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).NotEmpty();
            RuleFor(x => x.Electricity).GreaterThan(0).NotEmpty();
            RuleFor(x => x.Water).GreaterThan(0).NotEmpty();
            RuleFor(x => x.NaturalGas).GreaterThan(0).NotEmpty();
            RuleFor(x => x.Dues).GreaterThan(0).NotEmpty();
        }

    }
}
