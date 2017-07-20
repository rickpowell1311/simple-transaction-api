using LiteDB;
using Microsoft.AspNetCore.Mvc;
using SimpleTransactions.Api.Domain;
using SimpleTransactions.Api.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return transactions
                .FindAll()
                .Select(t => new TransactionModels.Get(t));
        }

        [HttpGet("api/transaction/{id}")]
        public TransactionModels.Get Fetch(int id)
        {
            var transaction = transactions
                .FindOne(t => t.Id == id);

            Ensure.This(transaction).CompliesWith(t => t != null, $"Cannot find transaction with id '{id}'");

            return new TransactionModels.Get(transaction);
        }

        [HttpPost("api/transaction")]
        public IActionResult Insert([FromBody]TransactionModels.Post model)
        {
            var transaction = Transaction.Create(
                model.TransactionAmount,
                model.CurrencyCode,
                model.TransactionDate,
                model.Description,
                model.Merchant);

            transactions.Insert(transaction);

            return Created("api/transaction", transaction);
        }

        [HttpPut("api/transaction")]
        public IActionResult Update([FromBody]TransactionModels.Put model)
        {
            var transaction = transactions
                .FindOne(t => t.Id == model.TransactionId);

            Ensure.This(transaction).CompliesWith(t => t != null, $"Cannot find transaction with id '{model.TransactionId}'");

            transaction.SetAmount(model.CurrencyCode, model.TransactionAmount);
            transaction.SetDescription(model.Description);
            transaction.SetMerchant(model.Merchant);
            transaction.SetTransactionDate(model.TransactionDate);

            return Ok(transaction);
        }

        [HttpDelete("api/transaction/{id}")]
        public IActionResult Delete(int id)
        {
            transactions.Delete(t => t.Id == id);

            return NoContent();
        }
    }
}
