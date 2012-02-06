// -----------------------------------------------------------------------
// <copyright file="DebriefingTest.cs" company="Secretariat of the Pacific Community">
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
    public class DebriefingTest : BaseTest
    {
        private DebriefRepository<Debriefing> repo;

        [TestFixtureSetUp]
        public void SetUp()
        {
            this.repo = new DebriefRepository<Debriefing>(DebriefDataService.GetSession());
        }

        [Test]
        public void TestGetDebriefing()
        {
            var debriefing = repo.FindBy(1);
            Assert.NotNull(debriefing);
            Assert.NotNull(debriefing.Evaluations);
            Assert.True(debriefing.HasFilledEvaluation());
            Assert.True(debriefing.IsReadOnly());
            Assert.GreaterOrEqual(285, debriefing.Evaluations.Count);
            int trueCount = debriefing.Evaluations.Count(e => e.Correct);
            Assert.GreaterOrEqual(220, trueCount);
            int trueAndExcellentCount = debriefing.Evaluations.Count(e => e.Correct && e.Excellent);
            Assert.GreaterOrEqual(4, trueAndExcellentCount);
            Assert.NotNull(debriefing.Observer);
            Assert.NotNull(debriefing.Vessel);
            Assert.NotNull(debriefing.Debriefer);
            Assert.NotNull(debriefing.DeparturePort);
            Assert.NotNull(debriefing.ReturnPort);
        }

        [Test]
        public void TestLongLineDebriefing()
        {
            var debriefing = repo.FindBy(2);
            Assert.NotNull(debriefing);
            var yearEvaluations =
                from ev in debriefing.Evaluations
                where ev.QuestionNumber < 9
                select ev;
            foreach (var evaluation in yearEvaluations)
            {
                Assert.IsTrue(evaluation.YearOfRevision.HasValue);
                Assert.AreEqual(2007, evaluation.YearOfRevision.Value);
            }
        }
    }
}
