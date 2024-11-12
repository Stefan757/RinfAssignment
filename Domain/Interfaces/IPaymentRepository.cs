using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPaymentRepository : IRepositoryBase<Payment>
    {
        Result<Payment> Create(int transactionId, PaymentType paymentType, decimal value);
    }
}
