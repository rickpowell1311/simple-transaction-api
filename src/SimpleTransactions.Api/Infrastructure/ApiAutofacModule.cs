using Autofac;
using LiteDB;
using SimpleTransactions.Api.Domain;

namespace SimpleTransactions.Api.Infrastructure
{
    public class ApiAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new LiteDatabase("simpletransactions.db"))
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.Register(ctx =>
            {
                var db = ctx.Resolve<LiteDatabase>();
                return db.GetCollection<Transaction>();
            }).AsSelf();
        }
    }
}
