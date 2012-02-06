// -----------------------------------------------------------------------
// <copyright file="VesselTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Debriefer.Dal.Tests
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
    using System.Linq;
    using NUnit.Framework;
    using Spc.Ofp.Debriefer.Dal.Common;
    using Spc.Ofp.Debriefer.Dal.Entities;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class VesselTest : BaseTest
    {
        private DebriefRepository<Vessel> repo;

        [TestFixtureSetUp]
        public void SetUp()
        {
            this.repo = new DebriefRepository<Vessel>(DebriefDataService.GetSession());
        }

        [Test]
        public void TestGetVessel()
        {
            var vessel = repo.FindBy(23946);
            Assert.NotNull(vessel);
            Assert.AreEqual("RED ROBIN 888", vessel.Name.Trim());
            Assert.AreEqual(VesselType.PS, vessel.VesselType);

        }
    }
}
