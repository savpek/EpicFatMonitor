using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using EpicFatMonitor.App_Start;
using EpicFatMonitor.Domain;
using NHibernate;

namespace EpicFatMonitor
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/fwlink/?LinkId=301868
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var resolver = new AutofacWebApiDependencyResolver(
                ResolveContainer());

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private IContainer ResolveContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register(c => Storage.CreateSessionFactory()).As<ISessionFactory>().SingleInstance();

            return builder.Build();
        }
    }
}
