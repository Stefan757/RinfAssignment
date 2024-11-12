using Application.DataTransferObjects.Article;
using Application.DataTransferObjects.Customer;
using Application.DataTransferObjects.Payment;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Transaction
{
    public class TransactionDto : EntityBase
    {
        public int CustomerId { get; set; }

        public CustomerDto? Customer { get; set; }

        public List<ArticleDto>? Articles { get; set; }

        public List<ArticleTransactionDto>? ArticlesTransaction { get; set; }

        public decimal? Total { get; init; }

        public decimal? Paid { get; init; }

        public List<PaymentDto>? Payments { get; set; }

        public TransactionStatus Status { get; set; }
    }
}
