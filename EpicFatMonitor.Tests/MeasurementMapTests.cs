using System;
using System.Collections.Generic;
using EpicFatMonitor.Domain.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Mapping;
using WebApplication1.Tests.Framework;

namespace WebApplication1.Tests
{
    [TestClass]
    public class MeasurementMapTests
    {
        private ISessionFactory _sessionFactory;

        [TestInitialize]
        public void Init()
        {
            _sessionFactory = new InMemorySessionFactory();
        }

        [TestMethod]
        public void Save_WorkWithoutErrors()
        {
            using(var session = _sessionFactory.OpenSession())
            {
                var test = new Measurement {Time = DateTime.Now, Weight = 120.3};
                
                session.SaveOrUpdate(test);
            }
        }

        [TestMethod]
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

        [TestMethod]
        public void Read_ReturnsDataCorrectly2()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                for (int i = 0; i < 10000; i++)
                {
                    session.SaveOrUpdate(new Measurement { Time = DateTime.Now, Weight = 10});
                }



                //var results = session.QueryOver<Measurement>().Where(x => Math.Abs(x.Weight - 10) < 0.1);

            }
        }
    }
}
