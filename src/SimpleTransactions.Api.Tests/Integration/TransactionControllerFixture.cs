using Autofac.Extensions.DependencyInjection;
using LiteDB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using SimpleTransactions.Api.Domain;
using System;
using System.Net.Http;

namespace SimpleTransactions.Api.Tests.Integration
{
    public class TransactionControllerFixture : IDisposable
    {
        public TestServer Server { get; }

        public HttpClient Client { get; }

        public TransactionControllerFixture()
        {
            Server = new TestServer(new WebHostBuilder()
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>());

            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            var liteDatabase = (LiteDatabase)Server.Host.Services.GetService(typeof(LiteDatabase));
            var transactions = liteDatabase.GetCollection<Transaction>();

            transactions.Delete(t => true); // Delete all transactions
        }
    }
}
