using Application.DataTransferObjects.Transaction;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class TransactionCreationDtoValidator : AbstractValidator<TransactionCreationDto>
    {
        public TransactionCreationDtoValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0);
            RuleForEach(x => x.Articles).SetValidator(new NewArticleTransactionDtoValidator());
        }
    }
}
