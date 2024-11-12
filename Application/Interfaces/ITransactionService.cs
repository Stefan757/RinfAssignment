using Application.DataTransferObjects.Transaction;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITransactionService
    {
        Result<TransactionDto> CreateTransaction(TransactionCreationDto transactionCreationDto);

        List<TransactionDto> GetAll();

    }
}
