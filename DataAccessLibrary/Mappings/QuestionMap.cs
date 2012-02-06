// -----------------------------------------------------------------------
// <copyright file="QuestionMap.cs" company="Secretariat of the Pacific Community">
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
    public class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            ReadOnly();
            Table("[dbo].[ref_dq_quest]");
            Id(x => x.Id, "question_id").GeneratedBy.Identity();
            Map(x => x.Version, "versn_id").CustomType(typeof(WorkbookVersion));
            Map(x => x.Number, "question_no");
            Map(x => x.Description, "question_desc");
            Map(x => x.Code, "question_code");
            Map(x => x.GearCode, "gear_code");
            Map(x => x.Constraint, "answerspace_id").CustomType(typeof(Constraint));
            References(x => x.Category).Column("cat_id");
        }
    }
}
