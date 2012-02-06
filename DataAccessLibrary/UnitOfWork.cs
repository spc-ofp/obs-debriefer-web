// -----------------------------------------------------------------------
// <copyright file="UnitOfWork.cs"  company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
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
    using NHibernate;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            this.Session = sessionFactory.OpenSession();
            this.Session.FlushMode = FlushMode.Auto;
            this.transaction = this.Session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        
        private bool disposed; // Necessary for IDisposable

        private readonly ISessionFactory sessionFactory;

        private readonly ITransaction transaction;

        public ISession Session { get; private set; }      

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            if (!this.transaction.IsActive)
            {
                throw new InvalidOperationException("No active transaction");
            }

            this.transaction.Commit();
        }

        public void Rollback()
        {
            if (this.transaction.IsActive)
            {
                this.transaction.Rollback();
            }
        }

        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called
            if (!this.disposed)
            {
                // If disposing is true, dispose all managed and unmanaged resources
                if (disposing)
                {
                    lock (this.Session)
                    {
                        if (this.Session.IsOpen)
                        {
                            this.Session.Close();
                        }
                    }

                    this.sessionFactory.Close();
                }

                this.disposed = true;
            }
        }
    }
}