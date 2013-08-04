using System;
using System.Collections.Generic;
using EpicFatMonitor.Controllers;
using EpicFatMonitor.Domain;
using EpicFatMonitor.Domain.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WebApplication1.Tests.Framework;

namespace EpicFatMonitor.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private InMemorySessionFactory _sessionFactory;
        private ILoginInformation _loginInformation;
        private UserController _controller;

        [TestInitialize]
        public void Init()
        {
            _sessionFactory = new InMemorySessionFactory();
            _loginInformation = Substitute.For<ILoginInformation>();
            _controller = new UserController(_sessionFactory, _loginInformation);
        }

        [TestMethod]
        public void Get_IfLoggedIn_ReturnUserCorrectly()
        {
            // Arrange.
            var user = new User {Email = "savolainen.pekka@gmail.com", Measurements = new List<Measurement>()};
            user.AddMeasurement(new Measurement {Time = DateTime.Now, Weight = 120});
            user.AddMeasurement(new Measurement { Time = DateTime.Now.AddDays(-1), Weight = 119.5 });
            user.AddMeasurement(new Measurement { Time = DateTime.Now.AddDays(-2), Weight = 119.2 });
            
            _loginInformation.CurrentUser().Returns(user);

            // Act and assert.
            _controller.Get().ShouldBeEquivalentTo(user);
        }

        [TestCleanup]
        public void CleanUp()
        {
            _sessionFactory.Dispose();
        }
    } 
}
