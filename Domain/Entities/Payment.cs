using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment : EntityBase
    {
        public PaymentType PaymentType { get; set; }

        public decimal Value { get; set; }

        public int TransactionId { get; set; }

        public Transaction? Transaction { get; set; }

    }
}
