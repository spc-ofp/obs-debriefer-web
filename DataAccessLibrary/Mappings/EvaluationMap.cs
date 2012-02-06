// -----------------------------------------------------------------------
// <copyright file="EvaluationMap.cs" company="Secretariat of the Pacific Community">
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
    public class EvaluationMap : ClassMap<Evaluation>
    {
        public EvaluationMap()
        {
            Table("[dbo].[deb_evaluation]");
            Id(x => x.Id, "deb_evaluation_id").GeneratedBy.Identity();
            Map(x => x.QuestionNumber, "question_no");
            Map(x => x.Correct, "correct");
            Map(x => x.Incomplete, "incomplete");
            Map(x => x.IncompleteRetrieved, "incomplete_retrieved");
            Map(x => x.Error, "error");
            Map(x => x.ErrorRetrieved, "error_retrieved");
            Map(x => x.XFactor, "x_factor");
            Map(x => x.Rgkt, "rgkt");
            Map(x => x.DidNotEncounter, "did_not_encounter");
            Map(x => x.YearOfRevision, "year_of_revision");
            Map(x => x.Weak, "weak");
            Map(x => x.Good, "good");
            Map(x => x.VeryGood, "very_good");
            Map(x => x.Excellent, "excellent");
            Map(x => x.Notes, "notes");
            Map(x => x.Processed, "processed_flag");
            References(x => x.Debriefing).Column("debriefing_id");
        }
    }
}
