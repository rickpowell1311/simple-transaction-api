namespace SimpleTransactions.Api.Infrastructure.Validation
{
    public static class Ensure
    {
        public static EnsureThis<T> This<T>(T obj)
        {
            return new EnsureThis<T>(obj);
        }
    }
}
