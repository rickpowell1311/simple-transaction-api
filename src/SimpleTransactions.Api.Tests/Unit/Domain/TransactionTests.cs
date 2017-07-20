using FakeItEasy;
using SimpleTransactions.Api.Domain;
using System;
using Xunit;

namespace SimpleTransactions.Api.Tests.Unit.Domain
{
    public class TransactionTests
    {
        [Fact]
        public void SetAmount_DoesNotAllowZero()
        {
            var transaction = A.Fake<Transaction>();

            Assert.Throws<InvalidOperationException>(() => transaction.SetAmount(A<CurrencyCode>._, 0m));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void SetDescription_WillNotBeSetIfNullOrWhitespace(string description)
        {
            var transaction = A.Fake<Transaction>();

            transaction.SetDescription(description);

            Assert.Null(transaction.Description);
        }

        [Fact]
        public void SetDescription_CannotBeLongerThan500Characters()
        {
            var invalidDescription = string.Empty;
            for (int i = 0; i < 501; i++)
            {
                invalidDescription += "a";
            }

            var transaction = A.Fake<Transaction>();

            Assert.Throws<InvalidOperationException>(() => transaction.SetDescription(invalidDescription));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void SetMerchant_WillNotBeSetIfNullOrWhitespace(string merchant)
        {
            var transaction = A.Fake<Transaction>();

            transaction.SetMerchant(merchant);

            Assert.Null(transaction.Description);
        }

        [Fact]
        public void SetMerchant_CannotBeLongerThan50Characters()
        {
            var invalidMerchant = string.Empty;
            for (int i = 0; i < 51; i++)
            {
                invalidMerchant += "a";
            }

            var transaction = A.Fake<Transaction>();

            Assert.Throws<InvalidOperationException>(() => transaction.SetMerchant(invalidMerchant));
        }

        [Fact]
        public void SetTransactionDate_CannotBeEarlierThanTheYear2000()
        {
            var transaction = A.Fake<Transaction>();

            var invalidDate = new DateTime(1999, 12, 31);

            Assert.Throws<InvalidOperationException>(() => transaction.SetTransactionDate(invalidDate));
        }

        [Fact]
        public void SetTransaction_CannotBeInTheFuture()
        {
            var transaction = A.Fake<Transaction>();

            var invalidDate = DateTime.Now.AddDays(1);

            Assert.Throws<InvalidOperationException>(() => transaction.SetTransactionDate(invalidDate));
        }
    }
}
