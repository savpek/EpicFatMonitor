using System;
using System.Collections.Generic;
using System.Data;
using EpicFatMonitor.Domain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Engine;
using NHibernate.Metadata;
using NHibernate.Stat;
using NHibernate.Tool.hbm2ddl;

namespace WebApplication1.Tests.Framework
{
    public class InMemorySessionFactory : ISessionFactory
    {
        private ISessionFactory _factory;
        private Configuration _configuration;

        public InMemorySessionFactory()
        {
            _factory = Fluently.Configure()
                  .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                  .Mappings(m =>
                    m.FluentMappings.AddFromAssemblyOf<Storage>())
                  .ExposeConfiguration(conf => _configuration = conf)
                  .BuildSessionFactory();
        }

        public void Dispose()
        {
            _factory.Dispose();
            _factory.Close();
        }


        public void Close()
        {
            _factory.Close();
            _factory.Dispose();
        }

        public ISession OpenSession()
        {
            ISession session = _factory.OpenSession();

            var export = new SchemaExport(_configuration);
            export.Execute(true, true, false, session.Connection, null);

            return session;
        }

        #region UnImplementedMethods
        
        public ISession OpenSession(IDbConnection conn)
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession(IInterceptor sessionLocalInterceptor)
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession(IDbConnection conn, IInterceptor sessionLocalInterceptor)
        {
            throw new NotImplementedException();
        }



        public IClassMetadata GetClassMetadata(Type persistentClass)
        {
            throw new NotImplementedException();
        }

        public IClassMetadata GetClassMetadata(string entityName)
        {
            throw new NotImplementedException();
        }

        public ICollectionMetadata GetCollectionMetadata(string roleName)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IClassMetadata> GetAllClassMetadata()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, ICollectionMetadata> GetAllCollectionMetadata()
        {
            throw new NotImplementedException();
        }


        public void Evict(Type persistentClass)
        {
            throw new NotImplementedException();
        }

        public void Evict(Type persistentClass, object id)
        {
            throw new NotImplementedException();
        }

        public void EvictEntity(string entityName)
        {
            throw new NotImplementedException();
        }

        public void EvictEntity(string entityName, object id)
        {
            throw new NotImplementedException();
        }

        public void EvictCollection(string roleName)
        {
            throw new NotImplementedException();
        }

        public void EvictCollection(string roleName, object id)
        {
            throw new NotImplementedException();
        }

        public void EvictQueries()
        {
            throw new NotImplementedException();
        }

        public void EvictQueries(string cacheRegion)
        {
            throw new NotImplementedException();
        }

        public IStatelessSession OpenStatelessSession()
        {
            throw new NotImplementedException();
        }

        public IStatelessSession OpenStatelessSession(IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public FilterDefinition GetFilterDefinition(string filterName)
        {
            throw new NotImplementedException();
        }

        public ISession GetCurrentSession()
        {
            throw new NotImplementedException();
        }

        public IStatistics Statistics { get; private set; }
        public bool IsClosed { get; private set; }
        public ICollection<string> DefinedFilterNames { get; private set; }

        #endregion UnImplementedMethods
    }
}