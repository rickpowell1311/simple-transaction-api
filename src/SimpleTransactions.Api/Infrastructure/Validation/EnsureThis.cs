using System;

namespace SimpleTransactions.Api.Infrastructure.Validation
{
    public class EnsureThis<T>
    {
        private T obj;

        public EnsureThis(T obj)
        {
            this.obj = obj;
        }

        public void CompliesWith(Func<T, bool> validationRule, string messageIfValidationFails)
        {
            if (!validationRule(obj))
            {
                throw new InvalidOperationException(messageIfValidationFails);
            }
        }
    }
}
