using SimpleTransactions.Api.Domain;
using System;

namespace SimpleTransactions.Api.Features.Transactions
{
    public static class TransactionModels
    {
        public class Get
        {
            public int TransactionId { get; set; }

            public DateTime TransactionDate { get; set; }

            public string Description { get; set; }

            public decimal TransactionAmount { get; set; }

            public DateTime CreatedDate { get; set; }

            public DateTime ModifiedDate { get; set; }

            public CurrencyCode CurrencyCode { get; set; }
            
            public string Merchant { get; set; }
        }

        public class Post
        {
            public DateTime TransactionDate { get; set; }

            public string Description { get; set; }

            public decimal TransactionAmount { get; set; }

            public CurrencyCode CurrencyCode { get; set; }

            public string Merchant { get; set; }
        }

        public class Put
        {
            public int TransactionId { get; set; }

            public DateTime TransactionDate { get; set; }

            public string Description { get; set; }

            public decimal TransactionAmount { get; set; }

            public CurrencyCode CurrencyCode { get; set; }

            public string Merchant { get; set; }
        }
    }
}
