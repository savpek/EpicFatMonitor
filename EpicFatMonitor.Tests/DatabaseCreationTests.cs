using NUnit.Framework;
using WebApplication1.Tests.Framework;

namespace EpicFatMonitor.Tests
{
    [TestFixture]
    public class DatabaseCreationTests
    {
        [Test]
        public void DatabaseSchemaIsCreatedWithoutErrorsFromObjects()
        {
            var factory = new InMemorySessionFactory();
            factory.OpenSession();
        }
    }
}
