using Application.DataTransferObjects.Customer;
using Application.DataTransferObjects.Payment;
using Application.DataTransferObjects.Transaction;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BusinessServices
{
    public class TransactionService(IMapper mapper, ITransactionRepository transactionRepository, IValidator<TransactionCreationDto> validator) : ITransactionService
    {
        private readonly IMapper mapper = mapper;
        private readonly ITransactionRepository transactionRepository = transactionRepository;

        public Result<TransactionDto> CreateTransaction(TransactionCreationDto transactionCreationDto)
        {
            var validatorResult = validator.Validate(transactionCreationDto);
            if (!validatorResult.IsValid)
            {
                return new Result<TransactionDto>(new Error(validatorResult.ToString()));
            }

            var result = transactionRepository.Create(transactionCreationDto.CustomerId, mapper.Map<List<ArticleTransaction>>(transactionCreationDto.Articles));

            if (!result.Success)
            {
                return new Result<TransactionDto>(result.Error!);
            }

            return new Result<TransactionDto>(mapper.Map<TransactionDto>(result.Value!));
        }

        public List<TransactionDto> GetAll()
        {
            return mapper.Map<List<TransactionDto>>(transactionRepository.GetAll());
        }
    }
}
