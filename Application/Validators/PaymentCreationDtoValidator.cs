using Application.DataTransferObjects.Payment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class PaymentCreationDtoValidator : AbstractValidator<PaymentCreationDto>
    {
        public PaymentCreationDtoValidator()
        {
            RuleFor(x => x.TransactionId).GreaterThan(0);
            RuleFor(x => x.Value).GreaterThan(0);
        }
    }
}
