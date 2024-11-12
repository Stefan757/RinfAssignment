using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : EntityBase
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public List<Transaction>? Transactions { get; set; }
    }
}
