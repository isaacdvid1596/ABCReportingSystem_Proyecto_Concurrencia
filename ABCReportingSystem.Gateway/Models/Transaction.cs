using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCReportingSystem.Gateway.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        public IEnumerable<Error> Errors { get; set; }
    }
}
