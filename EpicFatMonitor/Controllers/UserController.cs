using System;
using System.Collections.Generic;
using System.Web.Http;
using EpicFatMonitor.Domain.Models;
using NHibernate;
using NHibernate.Mapping;

namespace EpicFatMonitor.Controllers
{
    public class UserController : ApiController
    {
        private readonly ISessionFactory _sessionFactory;

        public UserController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public object Get()
        {
            var foo = new List<Measurement> {new Measurement {Time = DateTime.Now, Weight = 120}};

            return new User {Email = "savolainen.pekka@gmail.com", Measurements = foo};
        }

        public void Put(User user)
        {
            return;
        }
    }
}
