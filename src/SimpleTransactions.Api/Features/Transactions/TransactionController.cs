using LiteDB;
using Microsoft.AspNetCore.Mvc;
using SimpleTransactions.Api.Domain;
using System;
using System.Collections.Generic;

namespace SimpleTransactions.Api.Features.Transactions
{
    public class TransactionController : Controller
    {
        private readonly LiteCollection<Transaction> transactions;

        public TransactionController(LiteCollection<Transaction> transactions)
        {
            this.transactions = transactions;
        }

        [HttpGet("api/transaction")]
        public IEnumerable<TransactionModels.Get> FetchAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("api/transaction/{id}")]
        public TransactionModels.Get Fetch(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("api/transaction")]
        public void Insert([FromBody]TransactionModels.Post model)
        {
            throw new NotImplementedException();
        }

        [HttpPut("api/transaction")]
        public void Update([FromBody]TransactionModels.Put model)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("api/transaction/{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
