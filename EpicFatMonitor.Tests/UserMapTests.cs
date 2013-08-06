using System;
using System.Collections.Generic;
using EpicFatMonitor.Domain.Models;
using FluentAssertions;
using NHibernate;
using NUnit.Framework;
using WebApplication1.Tests.Framework;

namespace WebApplication1.Tests
{
    [TestFixture]
    public class UserMapTests
    {
        private ISessionFactory _sessionFactory;

        [SetUp]
        public void Init()
        {
            _sessionFactory = new InMemorySessionFactory();
        }

        [Test]
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

                result.Measurements.ShouldAllBeEquivalentTo(measurements);
            }
        }
    }
}
