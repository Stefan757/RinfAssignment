using Application.DataTransferObjects.Payment;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPaymentService
    {
        Result<PaymentDto> CreatePayment(PaymentCreationDto paymentCreationDto);
    }
}
