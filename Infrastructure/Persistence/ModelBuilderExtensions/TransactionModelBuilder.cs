using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.ModelBuilderExtensions
{
    internal static class TransactionModelBuilder
    {
        internal static ModelBuilder BuildTransactionModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Transaction>()
                .Ignore(x => x.Total);

            modelBuilder.Entity<Transaction>()
                .HasMany(x => x.Articles)
                .WithMany(x => x.Transactions)
                .UsingEntity<ArticleTransaction>();

            modelBuilder.Entity<Transaction>()
                .HasMany(x => x.Payments)
                .WithOne(x => x.Transaction)
                .HasForeignKey(x => x.TransactionId);

            return modelBuilder;
        }
    }
}
