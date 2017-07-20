using SimpleTransactions.Api.Infrastructure.Validation;
using System;

namespace SimpleTransactions.Api.Domain
{
    public class Transaction
    {
        public int Id { get; protected set; }

        public DateTime Date { get; protected set; }

        public string Description { get; protected set; }

        public decimal Amount { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public DateTime? ModifiedDate { get; protected set; }

        public CurrencyCode CurrencyCode { get; protected set; }

        public string Merchant { get; protected set; }

        protected Transaction()
        {
        }

        public static Transaction Create(decimal amount, CurrencyCode currencyCode, DateTime date, string description = null, string merchant = null)
        {
            var transaction = new Transaction();
            transaction.SetAmount(currencyCode, amount);
            transaction.SetTransactionDate(date);
            transaction.SetDescription(description);
            transaction.SetMerchant(description);

            return transaction;
        }

        public void SetTransactionDate(DateTime date)
        {
            var earliestAllowedTransactionDate = new DateTime(2000, 01, 01);

            Ensure.This(date).CompliesWith(d => d.CompareTo(earliestAllowedTransactionDate) >= 0, "Transaction date cannot be earlier than 01-01-2000");
            Ensure.This(date).CompliesWith(d => d.CompareTo(DateTime.Now.Date) <= 0, "Transaction date cannot be in the future");

            Date = date;
        }

        public void SetAmount(CurrencyCode currencyCode, decimal amount)
        {
            Ensure.This(amount).CompliesWith(a => a != default(decimal), "Transaction amount cannot be 0");

            CurrencyCode = currencyCode;
            Amount = amount;
        }

        public void SetDescription(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                Ensure.This(description).CompliesWith(d => d.Length <= 500, "Character description should not be more than 500 characters");
                Description = description;
            }
        }

        public void SetMerchant(string merchant)
        {
            if (!string.IsNullOrWhiteSpace(merchant))
            {
                Ensure.This(merchant).CompliesWith(d => d.Length <= 50, "Merchant should not be more than 50 characters");
                Merchant = merchant;
            }
        }
    }
}
