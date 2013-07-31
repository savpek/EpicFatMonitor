using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Tests.Framework;

namespace WebApplication1.Tests
{
    [TestClass]
    public class DatabaseCreationTests
    {
        [TestMethod]
        public void DatabaseSchemaIsCreatedWithoutErrorsFromObjects()
        {
            var factory = new InMemorySessionFactory();
            factory.OpenSession();
        }
    }
}
