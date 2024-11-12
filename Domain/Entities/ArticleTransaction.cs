using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ArticleTransaction : EntityBase
    {
        public int NumberOfArticles { get; set; }

        public int ArticleId {  get; set; }

        public Article? Article { get; set; }

        public int TransactionId { get; set; }

        public Transaction? Transaction { get; set; }
    }
}
