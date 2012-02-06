// -----------------------------------------------------------------------
// <copyright file="StaffController.cs" company="Secretariat of the Pacific Community">
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
    using System.Linq;
    using System.Web.Mvc;
    using Spc.Ofp.Debriefer.Dal;
    using Spc.Ofp.Debriefer.Dal.Common;
    using Spc.Ofp.Debriefer.Dal.Entities;
    using WebUI.Models.ExtensionMethods;

    /// <summary>
    /// Lookup-only controller for adding Ajax autocomplete capabilities.
    /// </summary>
    public class StaffController : Controller
    {
        private readonly DebriefRepository<FieldStaff> repo;

        public StaffController()
        {
            repo = new DebriefRepository<FieldStaff>(DebriefDataService.GetSession());
        }

        // For some strange reason, ToString() wasn't working as expected in the LINQ query
        private static string Format(FieldStaff person)
        {
            return String.Format("{0} {1} ({2})", person.FirstName, person.FamilyName, person.StaffCode).Trim();
        }

        public ActionResult Find(string term)
        {
            var people = (
                from person in repo.FilterBy(p => p.FirstName.Contains(term) || p.FamilyName.Contains(term) || p.StaffCode.Contains(term))
                select new
                {
                    id = person.StaffCode.Trim(),
                    label = Format(person),
                    value = person.StaffCode.Trim(),
                }
            );
            return Json(people.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}
