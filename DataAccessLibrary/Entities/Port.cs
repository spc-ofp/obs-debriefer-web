// -----------------------------------------------------------------------
// <copyright file="Port.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Debriefer.Dal.Entities
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
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Spc.Ofp.Debriefer.Dal.Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Port
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string CountryCode { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(String.IsNullOrEmpty(this.Name) ? "Unknown" : this.Name.Trim());
            if (!String.IsNullOrEmpty(this.CountryCode))
            {
                builder.Append(" (").Append(this.CountryCode.Trim()).Append(")");
            }
            return builder.ToString();
        }
    }
}
