using System;
using SimpleTransactions.Api.Infrastructure;

namespace SimpleTransactions.Api.Domain
{
    public class Transaction : IEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        protected Transaction()
        {
        }
    }
}
