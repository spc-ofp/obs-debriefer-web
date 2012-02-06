// -----------------------------------------------------------------------
// <copyright file="DebriefDataService.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
[assembly: System.CLSCompliant(true)]
namespace Spc.Ofp.Debriefer.Dal
{
    
   /*
    * This file is part of TUBS.
    *
    * TUBS is free software: you can redistribute it and/or modify
    * it under the terms of the GNU Affero General Public License as published by
    * the Free Software Foundation, either version 3 of the License, or
    * (at your option) any later version.
    *  
    * TUBS is distributed in the hope that it will be useful,
    * but WITHOUT ANY WARRANTY; without even the implied warranty of
    * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    * GNU Affero General Public License for more details.
    *  
    * You should have received a copy of the GNU Affero General Public License
    * along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
    */
    using System;
    using System.Collections;
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;

    /// <summary>
    /// TODO: Update summary.
    /// FIXME:  Add localization
    /// http://www.hanselman.com/blog/GlobalizationInternationalizationAndLocalizationInASPNETMVC3JavaScriptAndJQueryPart1.aspx
    /// </summary>
    public static class DebriefDataService
    {
        private static ISessionFactory sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                return sessionFactory ?? (sessionFactory = CreateSessionFactory());
            }
        }

        public static UnitOfWork StartTransaction()
        {
            return new UnitOfWork(sessionFactory);
        }

        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }

        public static void Dispose()
        {
            SessionFactory.Close();
        }

        /// <summary>
        /// Execute will execute an arbitrary SQL statement using the specified parameter
        /// list as ordered (not named!) parameters.
        /// ORMs are great as far as they're great, but sometimes one needs a little more flexibility.
        /// Having said that, this is a very dangerous method as it requires the caller to pass ANSI
        /// SQL or at least budget for fixing issues when moving to a new database.
        /// </summary>
        /// <param name="sql">SQL query to be executed</param>
        /// <param name="list">Parameter list.  Can be omitted</param>
        /// <returns>Results of SQL query as List of objects.  
        /// If the query has a single column, the contained object will be strongly typed.
        /// Otherwise, the contained object is an object[] and value extraction is the callers responsibility.</returns>
        public static IList Execute(string sql, params object[] list)
        {
            IList results = new ArrayList();
            using (ISession session = GetSession())
            {
                var query = session.CreateSQLQuery(sql);
                for (int i = 0; i < list.Length; i++)
                {
                    query.SetParameter(i, list[i]);
                }
                results = query.List();
            }
            return results;
        }

        private static ISessionFactory CreateSessionFactory()
        {
            IPersistenceConfigurer cfg =
                MsSqlConfiguration.MsSql2008.ConnectionString(
                    c => c
                        .FromConnectionStringWithKey("TUBS"))
                .QuerySubstitutions("true 1, false 0, True 1, False 0, yes 'Y', no 'N', bw_or ^, bw_and &, bw_not ~")
                .ShowSql();

            return Fluently.Configure()
                .Database(cfg)
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}