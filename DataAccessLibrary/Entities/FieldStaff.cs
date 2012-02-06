// -----------------------------------------------------------------------
// <copyright file="FieldStaff.cs" company="Secretariat of the Pacific Community">
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
    public class FieldStaff
    {
        public virtual FieldStaffType? StaffType { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string FamilyName { get; set; }
        public virtual string StaffCode { get; protected set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (!String.IsNullOrEmpty(this.FirstName))
            {
                builder.Append(this.FirstName.Trim());
            }
            if (!String.IsNullOrEmpty(this.FamilyName))
            {
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }
                builder.Append(this.FamilyName);
            }
            if (!String.IsNullOrEmpty(this.StaffCode))
            {
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }
                builder.Append("(").Append(this.StaffCode).Append(")");
            }
            return builder.ToString();
        }
    }
}
