// -----------------------------------------------------------------------
// <copyright file="VesselController.cs" company="Secretariat of the Pacific Community">
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
    public class VesselController : Controller
    {
        private readonly DebriefRepository<Vessel> repo;

        public VesselController()
        {
            repo = new DebriefRepository<Vessel>(DebriefDataService.GetSession());
        }

        public ActionResult Find(string term)
        {
            var vessels = (
                from vessel in repo.FilterBy(v => v.Name.Contains(term))
                select new
                {
                    id = vessel.Id,
                    label = vessel.Name.Trim(),
                    value = vessel.Name.Trim(),
                    GearType = DebriefingExtensions.GearCodeFromVesselType(vessel.VesselType)
                }
            );
            return Json(vessels.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}
