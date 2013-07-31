using System.IO;
using EpicFatMonitor.Domain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace WebApplication1.Tests.Framework
{
    public class SessionFactoryForTests
    {
        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(
                SQLiteConfiguration.Standard
                  .UsingFile("firstProject.db")
              )
              .Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<SessionFactory>())
              .ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();
        }

        public void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists("firstProject.db"))
                File.Delete("firstProject.db");

            new SchemaExport(config)
              .Create(false, true);
        }
    }
}