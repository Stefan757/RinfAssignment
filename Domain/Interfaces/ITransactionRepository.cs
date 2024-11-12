using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
        Result<Transaction> Create(int customerId, List<ArticleTransaction> articleTransactions);
    }
}
