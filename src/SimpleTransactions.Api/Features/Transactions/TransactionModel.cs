﻿using SimpleTransactions.Api.Domain;
using System;

namespace SimpleTransactions.Api.Features.Transactions
{
    public static class TransactionModel
    {
        public class Get
        {
            public int TransactionId { get; set; }

            public DateTime TransactionDate { get; set; }

            public string Description { get; set; }

            public decimal TransactionAmount { get; set; }

            public DateTime CreatedDate { get; set; }

            public DateTime? ModifiedDate { get; set; }

            public CurrencyCode CurrencyCode { get; set; }
            
            public string Merchant { get; set; }

            public Get()
            {
            }

            public Get(Transaction transaction)
            {
                TransactionId = transaction.Id;
                TransactionDate = transaction.Date;
                Description = transaction.Description;
                TransactionAmount = transaction.Amount;
                CreatedDate = transaction.CreatedDate;
                ModifiedDate = transaction.ModifiedDate;
                CurrencyCode = transaction.CurrencyCode;
                Merchant = transaction.Merchant;
            }
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
