using Application.DataTransferObjects.Transaction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Customer
{
    public class CustomerDto : EntityBase
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public List<TransactionDto>? Transactions { get; set; }
    }
}
