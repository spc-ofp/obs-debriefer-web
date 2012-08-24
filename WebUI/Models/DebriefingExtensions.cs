// -----------------------------------------------------------------------
// <copyright file="DebriefingExtensions.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
namespace WebUI.Models.ExtensionMethods
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
    using System.Linq;
    using NHibernate;
    using Spc.Ofp.Debriefer.Dal;
    using Spc.Ofp.Debriefer.Dal.Common;
    using Spc.Ofp.Debriefer.Dal.Entities;

    /// <summary>
    /// Class holding extension methods for working with the Debriefing entity
    /// from the data access layer.
    /// </summary>
    public static class DebriefingExtensions
    {
        public static string GearCodeFromVesselType(VesselType vtype)
        {
            string gearCode = String.Empty;
            switch (vtype)
            {
                case VesselType.PS:
                    gearCode = "S";
                    break;
                case VesselType.LL:
                    gearCode = "L";
                    break;
                default:
                    break;
            }
            return gearCode;
        }

        public static void Encode(this Evaluation evaluation, Constraint constraint, string value)
        {
            if (null != evaluation && !String.IsNullOrEmpty(value))
            {
                switch (constraint)
                {
                    case Constraint.Default:
                        evaluation.Correct = "Cc".Equals(value, StringComparison.InvariantCulture);
                        evaluation.Incomplete = "Inc".Equals(value, StringComparison.InvariantCulture);
                        evaluation.IncompleteRetrieved = "InR".Equals(value, StringComparison.InvariantCulture);
                        evaluation.ErrorRetrieved = "ErR".Equals(value, StringComparison.InvariantCulture);
                        evaluation.XFactor = "X".Equals(value, StringComparison.InvariantCulture);
                        break;
                    case Constraint.FreeText:
                        int year = 0;
                        if (Int32.TryParse(value, out year))
                        {
                            evaluation.YearOfRevision = year;
                        }
                        break;
                    case Constraint.WrittenReport:
                        evaluation.Weak = "Wk".Equals(value, StringComparison.InvariantCulture);
                        evaluation.Good = "Gd".Equals(value, StringComparison.InvariantCulture);
                        evaluation.VeryGood = "Vg".Equals(value, StringComparison.InvariantCulture);
                        evaluation.Excellent = "Exc".Equals(value, StringComparison.InvariantCulture);
                        break;
                    case Constraint.YesNo:
                        evaluation.Correct = "Y".Equals(value, StringComparison.InvariantCulture);
                        evaluation.Error = "N".Equals(value, StringComparison.InvariantCulture);
                        break;
                    case Constraint.CorrectOrError:
                        evaluation.Correct = "Cc".Equals(value, StringComparison.InvariantCulture);
                        evaluation.Error = "Er".Equals(value, StringComparison.InvariantCulture);
                        break;
                    case Constraint.DefaultWithDne:
                        evaluation.Correct = "Cc".Equals(value, StringComparison.InvariantCulture);
                        evaluation.Incomplete = "Inc".Equals(value, StringComparison.InvariantCulture);
                        evaluation.IncompleteRetrieved = "InR".Equals(value, StringComparison.InvariantCulture);
                        evaluation.ErrorRetrieved = "ErR".Equals(value, StringComparison.InvariantCulture);
                        evaluation.XFactor = "X".Equals(value, StringComparison.InvariantCulture);
                        evaluation.DidNotEncounter = "DnE".Equals(value, StringComparison.InvariantCulture);
                        break;
                    default:
                        break;
                }
            }
        }

        public static string DefaultAnswer(Constraint constraint)
        {
            string retval = String.Empty;
            switch (constraint)
            {
                case Constraint.Default:
                case Constraint.CorrectOrError:
                case Constraint.DefaultWithDne:
                    retval = "Cc";
                    break;
                case Constraint.YesNo:
                    retval = "Y";
                    break;
                case Constraint.WrittenReport:
                    retval = "Gd";
                    break;
                default:
                    break;
            }
            return retval;
        }

        public static string Decode(this Evaluation evaluation, Constraint constraint)
        {
            string retval = String.Empty;
            if (null != evaluation)
            {
                switch (constraint)
                {
                    case Constraint.Default:
                        retval =
                            evaluation.Correct ? "Cc" :
                            evaluation.Incomplete ? "Inc" :
                            evaluation.IncompleteRetrieved ? "InR" :
                            evaluation.Error ? "Er" :
                            evaluation.ErrorRetrieved ? "ErR" :
                            evaluation.XFactor ? "X" :
                            String.Empty;
                        break;
                    case Constraint.FreeText:
                        retval =
                            evaluation.YearOfRevision.HasValue ? 
                            evaluation.YearOfRevision.Value.ToString() : evaluation.Notes;
                        break;
                    case Constraint.WrittenReport:
                        retval =
                            evaluation.Weak ? "Wk" :
                            evaluation.Good ? "Gd" :
                            evaluation.VeryGood ? "Vg" :
                            evaluation.Excellent ? "Exc" :
                            String.Empty;
                        break;
                    case Constraint.YesNo:
                        // TODO Verify these are the correct columns for Y/N
                        retval =
                            evaluation.Correct ? "Y" :
                            evaluation.Error ? "N" :
                            String.Empty;
                        break;
                    case Constraint.CorrectOrError:
                        retval =
                            evaluation.Correct ? "Cc" :
                            evaluation.Error ? "Er" :
                            String.Empty;
                        break;
                    case Constraint.DefaultWithDne:
                        retval =
                            evaluation.DidNotEncounter ? "DnE" :
                            evaluation.Correct ? "Cc" :
                            evaluation.Incomplete ? "Inc" :
                            evaluation.IncompleteRetrieved ? "InR" :
                            evaluation.Error ? "Er" :
                            evaluation.ErrorRetrieved ? "ErR" :
                            evaluation.XFactor ? "X" :
                            String.Empty;
                        break;
                    default:
                        retval = String.Empty;
                        break;
                }
            }
            return retval;
        }

        public static void FillDependentObjects(this Debriefing debrief, DebriefingHeaderViewModel dhvm, ISession session)
        {
            if (null != debrief && null != dhvm && null != session)
            {
                if (dhvm.VesselId != default(int))
                {
                    var vesselRepo = new DebriefRepository<Vessel>(session);
                    debrief.Vessel = vesselRepo.FindBy(dhvm.VesselId);
                }

                var staffRepo = new DebriefRepository<FieldStaff>(session);
                debrief.Observer = staffRepo.FindBy(dhvm.ObserverCode);
                debrief.Debriefer = staffRepo.FindBy(dhvm.DebrieferCode);

                var portRepo = new DebriefRepository<Port>(session);
                debrief.DeparturePort = portRepo.FindBy(dhvm.DeparturePortId);
                debrief.ReturnPort = portRepo.FindBy(dhvm.ReturnPortId);
            }
        }

        public static void FillFromHeader(this Debriefing debrief, DebriefingHeaderViewModel dhvm)
        {
            if (null != debrief && null != dhvm)
            {
                debrief.TripNumber = dhvm.TripNumber;
                debrief.Comments = dhvm.Comments;
                debrief.CountryCode = dhvm.CountryCode;
                debrief.DebriefEnd = dhvm.EndTime.HasValue ? dhvm.EndTime.Value : dhvm.StartTime;
                debrief.DebriefStart = dhvm.StartTime;
                debrief.DepartureDate = dhvm.DepartureDate;
                debrief.ReturnDate = dhvm.ReturnDate;
                if (Enum.IsDefined(typeof(WorkbookVersion), dhvm.Version))
                {
                    debrief.Version = (WorkbookVersion)Enum.Parse(typeof(WorkbookVersion), dhvm.Version);
                }
                debrief.GearCode = dhvm.GearCode;
            }
        }
        
        public static DebriefingHeaderViewModel AsHeader(this Debriefing debrief)
        {
            DebriefingHeaderViewModel dhvm = new DebriefingHeaderViewModel();
            dhvm.PositiveActionResponse = "No";
            if (null != debrief)
            {
                dhvm.Id = debrief.Id;
                dhvm.TripNumber = debrief.TripNumber;
                dhvm.ObserverCode = debrief.Observer.StaffCode;
                dhvm.VesselId = debrief.Vessel.Id;
                dhvm.VesselName = debrief.Vessel.Name.Trim();
                dhvm.VesselCountryCode = debrief.Vessel.CountryCode;
                dhvm.ProgramCode = debrief.Program.ToString();
                dhvm.GearCode = GearCodeFromVesselType(debrief.Vessel.VesselType);
                dhvm.PreviousGearCode = dhvm.GearCode;
                dhvm.GearOrVersionImpact = debrief.HasFilledEvaluation();
                dhvm.DepartureDate = debrief.DepartureDate;
                dhvm.DeparturePort = debrief.DeparturePort.ToString();
                dhvm.DeparturePortId = debrief.DeparturePort.Id;
                dhvm.ReturnDate = debrief.ReturnDate;
                dhvm.ReturnPort = debrief.ReturnPort.ToString();
                dhvm.ReturnPortId = debrief.ReturnPort.Id;
                dhvm.DebrieferCode = debrief.Debriefer.StaffCode;
                dhvm.StartTime = debrief.DebriefStart;
                dhvm.EndTime = debrief.DebriefEnd;
                dhvm.CountryCode = debrief.CountryCode;
                dhvm.Version = debrief.Version.GetValueOrDefault(WorkbookVersion.v2007).ToString();
                dhvm.PreviousVersion = dhvm.Version;
                dhvm.Status = debrief.Status.GetValueOrDefault(DebriefingStatus.Unknown).ToString();
                dhvm.Comments = debrief.Comments;
                dhvm.EnteredBy = debrief.EnteredBy;
                dhvm.EnteredDate = debrief.EnteredDate;
                // IsReadOnly is used by display logic
                dhvm.IsReadOnly = DebriefingStatus.Complete == debrief.Status.GetValueOrDefault(DebriefingStatus.Unknown);
            }
            return dhvm;
        }

        public static EvaluationSectionViewModel AsSection(this Debriefing debrief, string formType, IQueryable<Question> questions)
        {
            EvaluationSectionViewModel esvm = new EvaluationSectionViewModel(formType);

            EvaluationCategoryViewModel ecvm = new EvaluationCategoryViewModel();
            esvm.Categories.Add(ecvm);
            Category qCategory = null;
            bool first = true;
            foreach (var question in questions.OrderBy(q => q.Number))
            {
                if (first)
                {
                    ecvm.Title = question.Category.Description;
                    qCategory = question.Category;
                    first = false;
                }
                
                // When category changes...
                if (qCategory != question.Category)
                {
                    // 'Close' current category
                    ecvm = new EvaluationCategoryViewModel()
                    {
                        Title = question.Category.Description
                    };
                    esvm.Categories.Add(ecvm);
                    // DnE (Did Not Encounter) is a shortcut that applies to the entire category
                    if (question.Constraint == Constraint.DefaultWithDne)
                    {
                        ecvm.HasDidNotEncounter = true;
                    }
                    qCategory = question.Category;
                }
                EvaluationQuestionViewModel eqvm = new EvaluationQuestionViewModel()
                {
                    Number = question.Number,
                    Text = question.Description,
                    AnswerConstraints = question.Constraint
                };
                var answer = (
                    from e in debrief.Evaluations
                    where e.QuestionNumber == question.Number
                    select e).FirstOrDefault();
                if (null != answer)
                {
                    if (!answer.HasAnswer())
                    {
                        eqvm.DefaultAnswer = DefaultAnswer(question.Constraint);
                    }
                    eqvm.Notes = answer.Notes;
                    eqvm.Answer = answer.Decode(question.Constraint);
                }
                ecvm.Questions.Add(eqvm);
            }
            return esvm;
        }
    }
}