using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.ModelBuilderExtensions
{
    internal static class ArticleTransactionModelBuilder
    {
        internal static ModelBuilder BuildArticleTransactionModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleTransaction>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ArticleTransaction>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<ArticleTransaction>()
                .HasOne(x => x.Article)
                .WithMany(x => x.ArticleTransactions)
                .HasForeignKey(x => x.ArticleId);

            modelBuilder.Entity<ArticleTransaction>()
                .HasOne(x => x.Transaction)
                .WithMany(x => x.ArticlesTransaction)
                .HasForeignKey(x => x.TransactionId);

            return modelBuilder;
        }
    }
}
