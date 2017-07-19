using System;

namespace SimpleTransactions.Api.Domain
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        protected Transaction()
        {
        }
    }
}
