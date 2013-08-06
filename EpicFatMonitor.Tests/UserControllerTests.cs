using System;
using System.Collections.Generic;
using EpicFatMonitor.Controllers;
using EpicFatMonitor.Domain;
using EpicFatMonitor.Domain.Exceptions;
using EpicFatMonitor.Domain.Models;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using WebApplication1.Tests.Framework;

namespace EpicFatMonitor.Tests
{
    [TestFixture]
    public class UserControllerTests
    {
        private InMemorySessionFactory _sessionFactory;
        private ILoginInformation _loginInformation;
        private UserController _controller;

        [SetUp]
        public void Init()
        {
            _sessionFactory = new InMemorySessionFactory();
            _loginInformation = Substitute.For<ILoginInformation>();
            _controller = new UserController(_sessionFactory, _loginInformation);
        }

        [Test]
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

        [Test]
        public void Post_IfTargetUserAndCurrentUserDoesNotMatch_ThrowAccessDeniedError()
        {
            // Arrange.
            var user = new User {Email = "Trash@gmail.com"};
            _loginInformation.CurrentUser().Returns(user);
            var postData = new User {Email = "savolainen.pekka@gmail.com"};

            // Act and assert.
            _controller
                .Invoking(c => c.Post(postData))
                .ShouldThrow<AccessDeniedException>("Restricted! You can only update your current account or add new nonexisting one.");
        }

        [TearDown]
        public void CleanUp()
        {
            _sessionFactory.Dispose();
            _sessionFactory.Close();
        }
    } 
}
