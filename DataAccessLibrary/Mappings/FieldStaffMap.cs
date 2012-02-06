// -----------------------------------------------------------------------
// <copyright file="FieldStaffMap.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Debriefer.Dal.Mappings
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
    using FluentNHibernate.Mapping;
    using Spc.Ofp.Debriefer.Dal.Common;
    using Spc.Ofp.Debriefer.Dal.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FieldStaffMap : ClassMap<FieldStaff>
    {
        public FieldStaffMap()
        {
            ReadOnly();
            Table("[ref].[field_staff]");
            Id(x => x.StaffCode, "staff_code").GeneratedBy.Assigned();
            Map(x => x.FirstName, "first_name");
            Map(x => x.FamilyName, "family_name");
            Map(x => x.StaffType, "staff_type_id").CustomType(typeof(FieldStaffType));
        }
    }
}
