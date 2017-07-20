using LiteDB;
using System;
using System.Linq;
using Xunit;

namespace SimpleTransactions.Api.Tests.Infrastructure
{
    public class LiteDbTests : IDisposable
    {
        private readonly LiteDatabase db;

        public LiteDbTests()
        {
            db = new LiteDatabase("./testdb");
        }

        [Fact]
        public void CanRetrievePoco_WithProtectedSetters()
        {
            const string testContent = "test";

            var pocoWithProtectedSetters = PocoWithProtectedSetters.Create(testContent);

            var collection = db.GetCollection<PocoWithProtectedSetters>();
            collection.Insert(pocoWithProtectedSetters);

            collection = db.GetCollection<PocoWithProtectedSetters>();
            var retrieved = collection.FindAll();

            Assert.Single(retrieved);
            Assert.Equal(testContent, retrieved.Single().TestContent);
        }

        public class PocoWithProtectedSetters
        {
            public string TestContent { get; protected set; }

            public static PocoWithProtectedSetters Create(string testContent)
            {
                return new PocoWithProtectedSetters
                {
                    TestContent = testContent
                };
            }
        }

        public void Dispose()
        {
            db.GetCollection<PocoWithProtectedSetters>().Delete(p => true); // Delete all
            db.Dispose();
        }
    }
}
