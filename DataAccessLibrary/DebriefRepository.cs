// -----------------------------------------------------------------------
// <copyright file="DebriefRepository.cs" company="Secretariat of the Pacific Community">
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using NHibernate;
    using NHibernate.Linq;

    /// <summary>
    /// DebriefRepository wraps up NHibernate so that a repo per object type is not required.
    /// NOTE:  NHibernate considers any Session that has thrown an Exception to be in an undefined
    /// state.  Therefore, unlike JDBC, there's no point in handling exceptions here.
    /// </summary>
    /// <typeparam name="T">Any entity that can be mapped to a Fluent NHibernate entity.</typeparam>
    public class DebriefRepository<T>
    {
        private readonly ISession Session;

        public DebriefRepository(ISession session)
        {
            this.Session = session;
        }

        public T FindBy(object id)
        {
            return this.Session.Get<T>(id);
        }

        public bool Add(T entity)
        {
            this.Session.Save(entity);
            return true;
        }

        public bool Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                this.Session.Save(item);
            }
            return true;
        }

        public bool Update(T entity)
        {
            this.Session.Update(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            this.Session.Delete(entity);
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            foreach (T item in entities)
            {
                this.Session.Delete(item);
            }
            return true;
        }

        public IQueryable<T> All()
        {
            return this.Session.Query<T>();
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Okay to suppress for LINQ expressions")]
        public T FindBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return this.FilterBy(expression).SingleOrDefault();
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Okay to suppress for LINQ expressions")]
        public IQueryable<T> FilterBy(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return this.All().Where(expression).AsQueryable();
        }

        public PagedList<T> GetPagedList(int skip, int take)
        {
            var query = All();
            var count = query.Count();
            var currentPage = query.Skip(skip).Take(take).ToList();
            return new PagedList<T>()
            {
                Entities = currentPage,
                HasNext = (skip + take < count),
                HasPrevious = (skip > 0)
            };
        }
    }
}