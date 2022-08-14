using DTO.Message;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Validator.FluentValidation.Message
{
    public class CreateMessageRequestValidator : AbstractValidator<CreateMessageRequest>
    {
        //mesaj bölümü için gerekli olan şartlar verildi.
        public CreateMessageRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Subject).NotEmpty();
            RuleFor(x => x.Note).NotEmpty();
            RuleFor(x => x.Phone).Length(10);
        }
    }
}
