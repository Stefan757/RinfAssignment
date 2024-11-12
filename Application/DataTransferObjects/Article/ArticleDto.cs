using Application.DataTransferObjects.Transaction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Article
{
    public class ArticleDto : EntityBase
    {
        public required string Author { get; set; }

        public required string Title { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public List<TransactionDto>? Transactions { get; set; }

        public List<ArticleTransactionDto>? ArticleTransactions { get; set; }
    }
}
