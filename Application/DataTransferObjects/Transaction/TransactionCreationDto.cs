using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.Transaction
{
    public class TransactionCreationDto
    {
        public int CustomerId { get; set; }
        public required List<NewArticleTransactionDto> Articles { get; set; }
    }
}
