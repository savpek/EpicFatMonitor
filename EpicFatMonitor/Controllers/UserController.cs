using System.Web.Http;
using EpicFatMonitor.Domain;
using EpicFatMonitor.Domain.Models;
using NHibernate;

namespace EpicFatMonitor.Controllers
{
    public class UserController : ApiController
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ILoginInformation _loginInformation;

        public UserController(ISessionFactory sessionFactory, ILoginInformation loginInformation)
        {
            _sessionFactory = sessionFactory;
            _loginInformation = loginInformation;
        }

        public User Get()
        {
            return _loginInformation.CurrentUser();
        }

        public User Put()
        {
            return null;
        }
    }
}
