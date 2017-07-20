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
    }
}
