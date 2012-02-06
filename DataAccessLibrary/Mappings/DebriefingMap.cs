// -----------------------------------------------------------------------
// <copyright file="DebriefingMap.cs" company="Secretariat of the Pacific Community">
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
    /// Fluent NHibernate mapping for the debriefing header.
    /// </summary>
    public class DebriefingMap : ClassMap<Debriefing>
    {
        public DebriefingMap()
        {
            Table("[dbo].[debriefing]");
            Id(x => x.Id, "debriefing_id").GeneratedBy.Identity();
            Map(x => x.Program, "obsprg_code");
            Map(x => x.GearCode, "gear_code");
            Map(x => x.TripNumber, "tripno");
            Map(x => x.Version, "versn_id").CustomType(typeof(WorkbookVersion));
            Map(x => x.CountryCode, "country_code");
            Map(x => x.DepartureDate, "dep_date");
            Map(x => x.ReturnDate, "ret_date");
            Map(x => x.DebriefStart, "debrief_start_date");
            Map(x => x.DebriefEnd, "debrief_end_date");
            Map(x => x.Status, "debrief_status_id").CustomType(typeof(DebriefingStatus));
            Map(x => x.Comments, "comments");
            Map(x => x.EnteredBy, "entered_by");
            Map(x => x.EnteredDate, "entered_dtime");

            References(x => x.Vessel).Column("vessel_id");
            References(x => x.DeparturePort).Column("dep_port_id");
            References(x => x.ReturnPort).Column("ret_port_id");
            References(x => x.Observer).Column("staff_code");
            References(x => x.Debriefer).Column("debriefer_code");

            HasMany(x => x.Evaluations).KeyColumn("debriefing_id").Cascade.AllDeleteOrphan();
        }
    }
}
