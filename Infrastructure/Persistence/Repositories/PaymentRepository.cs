using Domain.Entities;
using Domain.Enums;
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
    public class PaymentRepository(DataBaseContext context) : RepositoryBase<Payment>(context), IPaymentRepository
    {
        private readonly DataBaseContext context = context;

        public Result<Payment> Create(int transactionId, PaymentType paymentType, decimal value)
        {
            using (var dbTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var transaction = context.Transaction
                        .Where(x => x.Id == transactionId)
                        .Include(x => x.ArticlesTransaction!).ThenInclude(x => x.Article)
                        .Include(x => x.Payments)
                        .FirstOrDefault();

                    if (transaction is null)
                    {
                        return new Result<Payment>(new Error("Invalid transactionId."));
                    }

                    decimal amountToBePaid = transaction.Total ?? 0 - transaction.Paid ?? 0;

                    if (amountToBePaid == 0)
                    {
                        return new Result<Payment>(new Error("Transaction already paid."));
                    }

                    if (amountToBePaid < value)
                    {
                        return new Result<Payment>(new Error("Value bigger than the cost."));
                    }

                    var payment = new Payment
                    {
                        TransactionId = transactionId,
                        PaymentType = paymentType,
                        Value = value
                    };

                    context.Payment.Add(payment);
                    context.SaveChanges();

                    if (amountToBePaid == value)
                    {
                        transaction.Status = TransactionStatus.Completed;
                        context.Update(transaction);
                        context.SaveChanges();
                    }

                    dbTransaction.Commit();

                    payment = context.Payment.Where(x => x.Id == payment.Id).Include(x => x.Transaction).First();

                    return new Result<Payment>(payment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    dbTransaction.Rollback();
                    throw;
                }
            }
        }
    }
}
