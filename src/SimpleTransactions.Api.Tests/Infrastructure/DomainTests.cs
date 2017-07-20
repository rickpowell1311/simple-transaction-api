using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xunit;

namespace SimpleTransactions.Api.Tests.Infrastructure
{
    public class DomainTests
    {
        [Fact]
        public void AllDomainModels_ShouldNotHaveAPublicParameterlessConstructor()
        {
            var domainEntities = typeof(Startup).GetTypeInfo().Assembly.GetTypes()
                .Where(t => t.Namespace.Contains("SimpleTransactions.Api.Domain") 
                && t.GetTypeInfo().IsClass
                && !t.GetTypeInfo().GetCustomAttributes().Any(attr => attr is CompilerGeneratedAttribute));

            foreach (var domainEntity in domainEntities)
            {
                var hasPublicParameterlessConstructor = domainEntity.GetConstructors()
                    .Any(constr => constr.GetParameters().Count() == 0 && constr.IsPublic);

                Assert.False(hasPublicParameterlessConstructor, $"Domain entities should not contain a public parameterless constructor, but entity '{domainEntity.Name}' does");
            }
        }
    }
}
