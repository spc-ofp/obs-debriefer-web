// -----------------------------------------------------------------------
// <copyright file="Evaluation.cs" company="Secretariat of the Pacific Community">
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
    public class Evaluation
    {
        public virtual int Id { get; protected set; }

        public virtual Debriefing Debriefing { get; set; }

        public virtual int QuestionNumber { get; set; }

        public virtual bool Correct { get; set; }

        public virtual bool Incomplete { get; set; }

        public virtual bool IncompleteRetrieved { get; set; }

        public virtual bool Error { get; set; }

        public virtual bool ErrorRetrieved { get; set; }

        public virtual bool XFactor { get; set; }

        public virtual bool Rgkt { get; set; }

        public virtual bool DidNotEncounter { get; set; }

        public virtual int? YearOfRevision { get; set; }

        public virtual bool Weak { get; set; }

        public virtual bool Good { get; set; }

        public virtual bool VeryGood { get; set; }

        public virtual bool Excellent { get; set; }

        public virtual string Notes { get; set; }

        public virtual bool Processed { get; set; }

        public virtual bool HasAnswer()
        {
            return this.Correct ||
                   this.DidNotEncounter ||
                   this.Error ||
                   this.ErrorRetrieved ||
                   this.Excellent ||
                   this.Good ||
                   this.Incomplete ||
                   this.IncompleteRetrieved ||
                   this.VeryGood ||
                   this.Weak ||
                   this.XFactor ||
                   this.Rgkt ||
                   this.YearOfRevision.HasValue ||
                   !String.IsNullOrEmpty(this.Notes);
        }

    }
}
