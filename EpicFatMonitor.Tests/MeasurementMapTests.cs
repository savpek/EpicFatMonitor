using System;
using EpicFatMonitor.Domain.Models;
using FluentAssertions;
using NHibernate;
using NUnit.Framework;
using WebApplication1.Tests.Framework;

namespace EpicFatMonitor.Tests
{
    [TestFixture]
    public class MeasurementMapTests
    {
        private ISessionFactory _sessionFactory;

        [SetUp]
        public void Init()
        {
            _sessionFactory = new InMemorySessionFactory();
        }

        [Test]
        public void Save_WorkWithoutErrors()
        {
            using(var session = _sessionFactory.OpenSession())
            {
                var test = new Measurement {Time = DateTime.Now, Weight = 120.3};
                
                session.SaveOrUpdate(test);
            }
        }

        [Test]
        public void Read_ReturnsDataCorrectly()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var test = new Measurement { Time = DateTime.Now, Weight = 95.3 };
                session.SaveOrUpdate(test);

                var results = session.QueryOver<Measurement>();

                results.RowCount().Should().Be(1);
                results.SingleOrDefault().ShouldBeEquivalentTo(test, o => o.Excluding(x => x.Id));
            }
        }
    }
}