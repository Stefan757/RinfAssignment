using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction : EntityBase
    {
        public int CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public List<Article>? Articles { get; set; }

        public List<ArticleTransaction>? ArticlesTransaction { get; set; }

        public decimal? Total
        {
            get
            {
                return
                    ArticlesTransaction is null || ArticlesTransaction.Any(x => x.Article is null) ?
                    null :
                    ArticlesTransaction.Select(x => x.Article?.Price * x.NumberOfArticles).Sum();
            }
        }

        public decimal? Paid
        {
            get
            {
                return
                    Payments is null ?
                    null :
                    Payments.Select(x => x.Value).Sum();
            }
        }

        public List<Payment>? Payments { get; set; }

        public TransactionStatus Status { get; set; }
    }
}
