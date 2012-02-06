// -----------------------------------------------------------------------
// <copyright file="Debriefing.cs" company="Secretariat of the Pacific Community">
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Spc.Ofp.Debriefer.Dal.Common;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Debriefing
    {
        public Debriefing()
        {
            Evaluations = new List<Evaluation>();
        }
        
        public virtual int Id { get; protected set; }

        [Display(ResourceType = typeof(FieldNames), Name = "GearCode")]
        public virtual string GearCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Vessel")]
        public virtual Vessel Vessel { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DeparturePort")]
        public virtual Port DeparturePort { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ReturnPort")]
        public virtual Port ReturnPort { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Observer")]
        public virtual FieldStaff Observer { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Debriefer")]
        public virtual FieldStaff Debriefer { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ObserverProgram")]
        public virtual ObserverProgram Program { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "TripNumber")]
        public virtual string TripNumber { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DepartureDate")]
        public virtual DateTime DepartureDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "ReturnDate")]
        public virtual DateTime ReturnDate { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DebriefStart")]
        public virtual DateTime DebriefStart { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "DebriefEnd")]
        public virtual DateTime DebriefEnd { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Status")]
        public virtual DebriefingStatus? Status { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Version")]
        public virtual WorkbookVersion? Version { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "CountryCode")]
        public virtual string CountryCode { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "Comments")]
        public virtual string Comments { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredBy")]
        public virtual string EnteredBy { get; set; }

        [Display(ResourceType = typeof(FieldNames), Name = "EnteredDate")]
        public virtual DateTime? EnteredDate { get; set; }

        public virtual IList<Evaluation> Evaluations { get; protected internal set; }

        public virtual void AddEvaluation(Evaluation evaluation)
        {
            evaluation.Debriefing = this;
            this.Evaluations.Add(evaluation);
        }

        public virtual bool HasFilledEvaluation()
        {
            var impactQuery =
                from evaluation in this.Evaluations
                where evaluation.HasAnswer()
                select evaluation;
            return impactQuery.Count() > 0;                    
        }

        public virtual bool IsReadOnly()
        {
            return this.Status.HasValue && this.Status.Value == DebriefingStatus.Complete;
        }
    }
}
