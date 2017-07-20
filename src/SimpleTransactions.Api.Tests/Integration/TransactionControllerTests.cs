using SimpleTransactions.Api.Features.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace SimpleTransactions.Api.Tests.Integration
{
    public class TransactionControllerTests : IClassFixture<TransactionControllerFixture>
    {
        private readonly TransactionControllerFixture fixture;

        public TransactionControllerTests(TransactionControllerFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async void CreateTransaction_Returns201()
        {
            var validTransaction = ValidTransaction();

            var response = await fixture.Client.PostAsJsonAsync("api/transaction", validTransaction);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(response.StatusCode, HttpStatusCode.Created);
        }

        [Fact]
        public async void FetchAllTransactions_ReturnsTransactions()
        {
            var validTransaction = ValidTransaction();
            await fixture.Client.PostAsJsonAsync("api/transaction", validTransaction);

            var response = await fixture.Client.GetAsync("api/transaction");
            var transactions = await response.Content.ReadAsJsonAsync<List<TransactionModels.Get>>();

            Assert.NotEmpty(transactions);
        }

        [Fact]
        public async void FetchTransactionById_ReturnsTransaction()
        {
            var validTransaction = ValidTransaction();
            await fixture.Client.PostAsJsonAsync("api/transaction", validTransaction);

            var fetchAllResponse = await fixture.Client.GetAsync("api/transaction");
            var transactions = await fetchAllResponse.Content.ReadAsJsonAsync<List<TransactionModels.Get>>();
            var transaction = transactions.First();

            var fetchResponse = await fixture.Client.GetAsync($"api/transaction/{transaction.TransactionId}");
            transaction = await fetchResponse.Content.ReadAsJsonAsync<TransactionModels.Get>();

            Assert.NotNull(transaction);
        }

        [Fact]
        public async void UpdateTransaction_Returns200()
        {
            var validTransaction = ValidTransaction();
            await fixture.Client.PostAsJsonAsync("api/transaction", validTransaction);

            var response = await fixture.Client.GetAsync("api/transaction");
            var transactions = await response.Content.ReadAsJsonAsync<List<TransactionModels.Get>>();

            var transaction = transactions.First();

            var updated = new TransactionModels.Put
            {
                TransactionId = transaction.TransactionId,
                CurrencyCode = transaction.CurrencyCode,
                Description = transaction.Description,
                Merchant = transaction.Merchant,
                TransactionAmount = transaction.TransactionAmount,
                TransactionDate = transaction.TransactionDate
            };

            var updatedResponse = await fixture.Client.PutAsJsonAsync("api/transaction", updated);

            Assert.Equal(HttpStatusCode.OK, updatedResponse.StatusCode);
        }

        [Fact]
        public async void DeleteTransaction_Returns204()
        {
            var validTransaction = ValidTransaction();
            await fixture.Client.PostAsJsonAsync("api/transaction", validTransaction);

            var response = await fixture.Client.GetAsync("api/transaction");
            var transactions = await response.Content.ReadAsJsonAsync<List<TransactionModels.Get>>();

            var transaction = transactions.First();

            var deleteResponse = await fixture.Client.DeleteAsync($"api/transaction/{transaction.TransactionId}");

            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        }

        private TransactionModels.Post ValidTransaction()
        {
            return new TransactionModels.Post
            {
                CurrencyCode = Domain.CurrencyCode.GBP,
                Description = "test description",
                Merchant = "test merchant",
                TransactionAmount = 10m,
                TransactionDate = new DateTime(2017, 01, 01)
            };
        }
    }
}
