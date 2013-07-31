using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using WebApplication1.Tests.Framework;

namespace WebApplication1.Tests
{
    [TestClass]
    public class DatabaseCreationTests
    {
        private ISessionFactory _sessionFactory;

        [TestInitialize]
        public void Init()
        {
        }

        [TestMethod]
        public void DatabaseSchemaIsCreatedWithoutErrorsFromObjects()
        {
            _sessionFactory = new SessionFactoryForTests().CreateSessionFactory();
        }
    }
}
