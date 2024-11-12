using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.ModelBuilderExtensions
{
    internal static class CustomerModelBuilder
    {
        internal static ModelBuilder BuildCustomerModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Customer>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
                .Property(x => x.Name).HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .Property(x => x.Email).HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                .HasMany<Transaction>()
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<Customer>().HasData
                (
                    new Customer { Id = 1, Name = "John Smith", Email = "john.smith@example.com"},
                    new Customer { Id = 2, Name = "Bob Bobber", Email = "bob.bobber@example.com"},
                    new Customer { Id = 3, Name = "Steve Corey", Email = "steve.corey@example.com"}
                );

            return modelBuilder;
        }
    }
}
