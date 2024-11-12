using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.ModelBuilderExtensions
{
    internal static class PaymentModelBuilder
    {
        internal static ModelBuilder BuildPaymentModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Payment>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            return modelBuilder;
        }
    }
}
