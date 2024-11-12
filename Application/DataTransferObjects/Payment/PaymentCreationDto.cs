using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Payment
{
    public class PaymentCreationDto
    {
        public int TransactionId { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Value { get; set; }
    }
}
