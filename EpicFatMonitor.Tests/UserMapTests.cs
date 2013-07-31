using System;
using System.Collections.Generic;
using EpicFatMonitor.Domain.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using WebApplication1.Tests.Framework;

namespace WebApplication1.Tests
{
    [TestClass]
    public class UserMapTests
    {
        private ISessionFactory _sessionFactory;

        [TestInitialize]
        public void Init()
        {
            _sessionFactory = SessionFactoryForTests.CreateSessionFactory();
        }

        [TestMethod]
        public void SaveOrUpdate_WorksCorrectly()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var measurements = new List<Measurement>
                {
                    new Measurement {Time = DateTime.Now, Weight = 100}
                };
                var user = new User {Email = "test@gmail.com", Measurements = measurements};
                
                session.SaveOrUpdate(user);
                var query = session.QueryOver<User>();

                var result = query.SingleOrDefault();
                result.Email.Should().Be("test@gmail.com");
                result.Measurements.ShouldAllBeEquivalentTo(measurements, o => o.Excluding(x => x.Id));
            }
        }
    }
}
