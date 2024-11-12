using Application.DataTransferObjects.Article;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Transaction
{
    public class ArticleTransactionDto : EntityBase
    {
        public int NumberOfArticles { get; set; }

        public int ArticleId { get; set; }

        public ArticleDto? Article { get; set; }

        public int TransactionId { get; set; }

        public TransactionDto? Transaction { get; set; }
    }
}
