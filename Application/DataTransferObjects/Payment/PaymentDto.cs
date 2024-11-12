using Application.DataTransferObjects.Transaction;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Payment
{
    public class PaymentDto : EntityBase
    {
        public PaymentType PaymentType { get; set; }

        public decimal Value { get; set; }

        public int TransactionId { get; set; }

        public TransactionDto? Transaction { get; set; }
    }
}
