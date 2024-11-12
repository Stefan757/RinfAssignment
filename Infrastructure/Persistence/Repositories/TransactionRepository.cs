using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class TransactionRepository(DataBaseContext context) : RepositoryBase<Transaction>(context), ITransactionRepository
    {
        private readonly DataBaseContext context = context;

        public Result<Transaction> Create(int customerId, List<ArticleTransaction> articleTransactions)
        {
            if (context.Customer.Find(customerId) is null)
            {
                return new Result<Transaction>(new Error("Invalid customerId."));
            }

            var transaction = new Transaction
            {
                CustomerId = customerId,
                Status = Domain.Enums.TransactionStatus.PaymentPending
            };

            using (var dbTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Transaction.Add(transaction);
                    context.SaveChanges();

                    foreach (var articleTransaction in articleTransactions)
                    {
                        var article = context.Article.Find(articleTransaction.ArticleId);
                        if (article == null)
                        {
                            dbTransaction.Rollback();
                            return new Result<Transaction>(new Error($"Invalid articleId : {articleTransaction.ArticleId}."));
                        }

                        if (article.Stock < articleTransaction.NumberOfArticles)
                        {
                            dbTransaction.Rollback();
                            return new Result<Transaction>(new Error($"Stock not available for articleId : {articleTransaction.ArticleId}."));
                        }

                        article.Stock -= articleTransaction.NumberOfArticles;
                        context.Article.Update(article);

                        articleTransaction.TransactionId = transaction.Id;
                        context.ArticleTransaction.Add(articleTransaction);
                    }
                    context.SaveChanges();

                    dbTransaction.Commit();

                    transaction = context.Transaction
                        .Where(x => x.Id == transaction.Id)
                        .Include(x => x.Customer)
                        .Include(x => x.Articles)
                        .Include(x => x.ArticlesTransaction!).ThenInclude(x => x.Article)
                        .First();
                }
                catch (DbUpdateConcurrencyException)
                {
                    dbTransaction.Rollback();
                    throw;
                }

                return new Result<Transaction>(transaction);
            }
        }

        public override List<Transaction> GetAll()
        {
            return context.Transaction
                .Include(x => x.Customer)
                .Include(x => x.Articles)
                .Include(x => x.ArticlesTransaction!).ThenInclude(x => x.Article)
                .Include(x => x.Payments)
                .ToList();
        }
    }
}
