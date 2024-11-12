using Domain.Entities;
using Infrastructure.Persistence.ModelBuilderExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .BuildCustomerModel()
                .BuildArticleModel()
                .BuildTransactionModel()
                .BuildArticleTransactionModel()
                .BuildPaymentModel();
        }

        public required DbSet<Customer> Customer { get; set; }
        public required DbSet<Article> Article { get; set; }
        public required DbSet<Transaction> Transaction { get; set; }
        public required DbSet<ArticleTransaction> ArticleTransaction { get; set; }
        public required DbSet<Payment> Payment { get; set; }
    }
}
