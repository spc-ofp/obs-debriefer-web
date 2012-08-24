// -----------------------------------------------------------------------
// <copyright file="DebriefingController.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace WebUI.Controllers
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
    using System.Linq;
    using System.Web.Mvc;
    using Spc.Ofp.Debriefer.Dal;
    using Spc.Ofp.Debriefer.Dal.Entities;
    using WebUI.Models;
    using WebUI.Models.ExtensionMethods;
    
    public class DebriefingController : Controller
    {        
        // Alert levels
        public const string ALERT_SUCCESS = "alert-success";
        public const string ALERT_DANGER = "alert-danger";
        public const string ALERT_ERROR = "alert-error";
        public const string ALERT_INFO = "alert-info";
        
        // Default page size
        const int PAGE_SIZE = 25;
        
        // These Repositories are read-only
        // Use a UnitOfWork and a transient repository for updates
        private readonly DebriefRepository<Debriefing> repo;
        private readonly DebriefRepository<Question> questionRepo;

        private static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(typeof(DebriefingController));

        public DebriefingController()
        {
            repo = new DebriefRepository<Debriefing>(DebriefDataService.GetSession());
            questionRepo = new DebriefRepository<Question>(DebriefDataService.GetSession());
        }

        // TODO Extract this into something used by all Controllers
        public void Flash(string message, string level = ALERT_ERROR)
        {
            ViewData["flash"] = message;
            ViewData["flash-level"] = level;
        }

        /// <summary>
        /// The questions associated with a debriefing depend on the observer workbook version and
        /// the vessel's gear type.
        /// </summary>
        /// <param name="debrief"></param>
        /// <param name="formType"></param>
        /// <returns></returns>
        private IQueryable<Question> QuestionsForDebrief(Debriefing debrief, string formType = "")
        {
            string gearCode = DebriefingExtensions.GearCodeFromVesselType(debrief.Vessel.VesselType);
            return String.Empty.Equals(formType) ?
                questionRepo.FilterBy(
                    q => q.Version == debrief.Version.Value &&
                         q.GearCode == gearCode) :
                questionRepo.FilterBy(
                    q => q.Version == debrief.Version.Value &&
                         q.GearCode == gearCode &&
                         q.Code == formType);
        }

        //
        // GET: /Debriefing/
        /// <summary>
        /// Get a list of debriefing domain objects.
        /// </summary>
        /// <param name="page">Page number (optional)</param>
        /// <returns>A list view of Debriefing domain objects</returns>
        public ActionResult Index(int? page)
        {
            var debriefings = repo.GetPagedList((page ?? 0) * PAGE_SIZE, PAGE_SIZE);
            ViewBag.HasPrevious = debriefings.HasPrevious;
            ViewBag.HasNext = debriefings.HasNext;
            ViewBag.CurrentPage = (page ?? 0);
            var headers = (
                from e in debriefings.Entities
                select e.AsHeader()
            );
            return View(headers);
        }

        //
        // GET: /Debriefing/Details/5
        public ActionResult Details(int id)
        {
            var debrief = repo.FindBy(id);
            if (null == debrief)
            {
                return View("NotFound");
            }
            DebriefingHeaderViewModel dhvm = debrief.AsHeader();

            var questions = QuestionsForDebrief(debrief);

            var codes = (
                from q in questions
                select q.Code
            ).Distinct();

            foreach (var code in codes)
            {
                var questionNumbersBySection =
                    from q in questions
                    where q.Code == code
                    select q.Number;

                // Yes, this looks dumb.  Unfortunately, I'm forced into
                // it by LINQ to NHibernate
                int filledCount = 0;
                foreach (var questionNumber in questionNumbersBySection)
                {
                    var eval = debrief.Evaluations.Where(e => e.QuestionNumber == questionNumber).FirstOrDefault();
                    if (null != eval && eval.HasAnswer())
                    {
                        filledCount++;
                    }
                }

                LOGGER.DebugFormat("Section {0} has question numbers: {1}", code, String.Join(",", questionNumbersBySection.ToList()));
                
                int totalCount = questionNumbersBySection.Count();
                decimal percentComplete = (0 == totalCount) ? 1 : (decimal)filledCount / (decimal)totalCount;
                percentComplete *= 100;

                LOGGER.DebugFormat("filledCount: {0}\ttotalCount: {1}\tpercentComplete: {2}", filledCount, totalCount, percentComplete);

                SectionStatusViewModel ssvm = new SectionStatusViewModel();
                ssvm.Name = code;
                ssvm.PercentComplete = (int)percentComplete;
                dhvm.SectionStatusList.Add(ssvm);
            }

            return View(dhvm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formType"></param>
        /// <returns></returns>
        public ActionResult EditByFormType(int id, string formType)
        {
            ViewBag.Id = id;
            ViewBag.FormType = formType;

            var debrief = repo.FindBy(id);
            if (null == debrief)
            {
                return View("NotFound");
            }
            if (debrief.IsReadOnly())
            {
                return RedirectToAction("ByFormType", new { id = id, formType = formType });
            }
            string gearCode = DebriefingExtensions.GearCodeFromVesselType(debrief.Vessel.VesselType);

            var questions = QuestionsForDebrief(debrief, formType);

            EvaluationSectionViewModel esvm = debrief.AsSection(formType, questions);
            ViewBag.Title = String.Format("Edit {0}", esvm.FormName);
            return View(esvm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formType"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditByFormType(int id, string formType, FormCollection form)
        {
            IDictionary<int, SimpleQuestion> simple = SimpleQuestion.FromForm(form);
            if (0 == simple.Count)
            {
                // Do something...
            }
            
            ViewBag.Id = id;
            ViewBag.FormType = formType;

            using (UnitOfWork uow = DebriefDataService.StartTransaction())
            {               
                var writeRepo = new DebriefRepository<Debriefing>(uow.Session);

                var debrief = writeRepo.FindBy(id);
                if (null == debrief)
                {
                    return View("NotFound");
                }
                if (debrief.IsReadOnly())
                {
                    return RedirectToAction("ByFormType", new { id = id, formType = formType });
                }
                string gearCode = DebriefingExtensions.GearCodeFromVesselType(debrief.Vessel.VesselType);

                var questions = QuestionsForDebrief(debrief, formType);

                // Iterate though questions associated with this form type
                // LINQ for NHibernate prevents us from doing more within the LINQ query --
                // it really only works for something that can be directly translated to SQL
                // Not that there's anything wrong with that...
                foreach (var question in questions)
                {
                    if (simple.ContainsKey(question.Number))
                    {
                        LOGGER.DebugFormat("Found question# {0}", question.Number);
                        SimpleQuestion sq = simple[question.Number];
                        Evaluation eval =
                            debrief.Evaluations.FirstOrDefault(e => e.QuestionNumber == question.Number) ??
                            new Evaluation()
                            {
                                QuestionNumber = question.Number,
                            };
                        if (null == eval.Debriefing)
                        {
                            LOGGER.Debug("Adding new evaluation");
                            debrief.AddEvaluation(eval);
                        }
                        eval.Notes = sq.Notes;
                        LOGGER.DebugFormat("Encoding value [{0}] with Constraint {1}", sq.Answer, question.Constraint);
                        eval.Encode(question.Constraint, sq.Answer);
                    }
                }

                try
                {
                    writeRepo.Update(debrief);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    Flash("Failed to update debriefing.  Please contact technical support.");
                    LOGGER.Error("Failed to update debriefing", ex);
                    return EditByFormType(id, formType);
                }
            }
            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult ByFormType(int id, string formType)
        {
            formType = Server.UrlDecode(formType);
            ViewBag.Id = id;
            ViewBag.FormType = formType;

            var debrief = repo.FindBy(id);
            if (null == debrief)
            {
                return View("NotFound");
            }

            string gearCode = DebriefingExtensions.GearCodeFromVesselType(debrief.Vessel.VesselType);
            var questions = QuestionsForDebrief(debrief, formType);
            EvaluationSectionViewModel esvm = debrief.AsSection(formType, questions);
            ViewBag.Title = esvm.FormName;
            return View(esvm);
        }

        //
        // GET: /Debriefing/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Debriefing/Create

        [HttpPost]
        public ActionResult Create(DebriefingHeaderViewModel dhvm)
        {
            // Model level validations
            if (ModelState.IsValidField("DepartureDate") && ModelState.IsValidField("ReturnDate"))
            {
                if (dhvm.ReturnDate.CompareTo(dhvm.DepartureDate) < 0)
                {
                    // This will prevent ModelState.IsValid from returning true
                    ModelState["ReturnDate"].Errors.Add("Return date can't be before departure date");
                }
            }
            
            if (ModelState.IsValid)
            {
                // Try and save
                Debriefing debrief = new Debriefing();
                debrief.FillFromHeader(dhvm);               
                // TODO Down the road, this method will only be available to authorized users
                // For now, add a debug value.
                debrief.EnteredBy = User.Identity == null ? "xyzzy@spc.int" : User.Identity.Name;
                debrief.EnteredDate = DateTime.Now;
                // Add empty evaluations that are appropriate for version and gear code
                // Do it here instead of FillFromHeader because we'll need access to the database
                // to come up with the questions.
                var questions = QuestionsForDebrief(debrief);
                foreach (var question in questions)
                {
                    debrief.AddEvaluation(new Evaluation()
                    {
                        QuestionNumber = question.Number
                    });
                }

                // Only start the transaction after we've done what we can without it.
                using (UnitOfWork uow = DebriefDataService.StartTransaction())
                {
                    debrief.FillDependentObjects(dhvm, uow.Session);                                      
                    var writeRepo = new DebriefRepository<Debriefing>(uow.Session);
                    try
                    {
                        writeRepo.Add(debrief);
                        uow.Commit();
                    }
                    catch (Exception ex)
                    {
                        Flash("Failed to save debriefing.  Please contact technical support.");
                        LOGGER.Error("Failed to save debriefing", ex);
                        return View(dhvm);
                    }
                }                
                return RedirectToAction("Index");
            }
            return View(dhvm);
        }
        
        //
        // GET: /Debriefing/Edit/5 
        public ActionResult Edit(int id)
        {
            var debrief = repo.FindBy(id);
            if (null == debrief)
            {
                return View("NotFound");
            }
            if (debrief.IsReadOnly())
            {
                return RedirectToAction("Details", new { id = id });
            }
            if (debrief.HasFilledEvaluation())
            {
                Flash("This debriefing has user-provided answers.  Changing gear type and/or version will delete these answers.", ALERT_INFO);
            }
            DebriefingHeaderViewModel dhvm = debrief.AsHeader();
            return View(dhvm);
        }

        //
        // POST: /Debriefing/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DebriefingHeaderViewModel dhvm)
        {
            using (UnitOfWork uow = DebriefDataService.StartTransaction())
            {
                var writeRepo = new DebriefRepository<Debriefing>(uow.Session);

                var debrief = writeRepo.FindBy(id);
                if (null == debrief)
                {
                    return View("NotFound");
                }

                debrief.FillFromHeader(dhvm);

                // If the version or gear code changes, there's the possibility that any existing
                // answers are invalid.  Either the question numbers have changed or the form types
                // are different (no way to give PS-1 form feedback for a long line trip!)
                // This is handled by clearing out any existing evaluations and re-creating the list based
                // on the new gear code and version.
                // If there is no existing user input, this happens without any required user interaction.
                // If there _is_ user input, then we require a positive action to delete the existing data.
                if (debrief.GearCode != dhvm.GearCode || debrief.Version.Value.ToString() != dhvm.Version)
                {
                    bool hasAnswers = debrief.HasFilledEvaluation();
                    if (!hasAnswers || (hasAnswers && "YES".Equals(dhvm.PositiveActionResponse, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        // Delete existing evaluations
                        debrief.Evaluations.Clear();
                        // Create new set of evaluations
                        var questions = QuestionsForDebrief(debrief);
                        foreach (var question in questions)
                        {
                            debrief.AddEvaluation(new Evaluation()
                            {
                                QuestionNumber = question.Number
                            });
                        }
                    }
                    else
                    {
                        Flash("Change to gear type and/or version can't be made without a positive action");
                        return View(dhvm);
                    }
                }

                // Fill in full blown objects
                debrief.FillDependentObjects(dhvm, uow.Session);

                try
                {
                    writeRepo.Update(debrief);
                    uow.Commit();
                }
                catch (Exception ex)
                {
                    Flash("Failed to update briefing.  Please contact IT");
                    LOGGER.Error(String.Format("Failed to update briefing with Id {0}", id), ex);
                    return View(dhvm);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
