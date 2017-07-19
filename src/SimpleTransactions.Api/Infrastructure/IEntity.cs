using System;

namespace SimpleTransactions.Api.Infrastructure
{
    public interface IEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime UpdatedOn { get; set; }
    }
}
