using Application.DataTransferObjects.Payment;
using Application.DataTransferObjects.Transaction;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessServices
{
    public class PaymentService(IPaymentRepository paymentRepository, IMapper mapper, IValidator<PaymentCreationDto> validator) : IPaymentService
    {
        public Result<PaymentDto> CreatePayment(PaymentCreationDto paymentCreationDto)
        {
            var validatorResult = validator.Validate(paymentCreationDto);
            if (!validatorResult.IsValid)
            {
                return new Result<PaymentDto>(new Error(validatorResult.ToString()));
            }

            var result = paymentRepository.Create(paymentCreationDto.TransactionId, paymentCreationDto.PaymentType, paymentCreationDto.Value);

            if (!result.Success)
            {
                return new Result<PaymentDto>(result.Error!);
            }

            return new Result<PaymentDto>(mapper.Map<PaymentDto>(result.Value!));
        }
    }
}
