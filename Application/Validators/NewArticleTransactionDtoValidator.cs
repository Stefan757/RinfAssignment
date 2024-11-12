using Application.DataTransferObjects.Transaction;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class NewArticleTransactionDtoValidator : AbstractValidator<NewArticleTransactionDto>
    {
        public NewArticleTransactionDtoValidator()
        {
            RuleFor(x => x.NumberOfArticles).GreaterThan(0);
            RuleFor(x => x.ArticleId).GreaterThan(0);
        }
    }
}
