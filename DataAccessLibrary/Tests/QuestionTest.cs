// -----------------------------------------------------------------------
// <copyright file="QuestionTest.cs" company="Secretariat of the Pacific Community">
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
    public class QuestionTest : BaseTest
    {
        private DebriefRepository<Question> repo;

        [TestFixtureSetUp]
        public void SetUp()
        {
            this.repo = new DebriefRepository<Question>(DebriefDataService.GetSession());
        }

        [Test]
        public void TestGetQuestion()
        {
            var question = repo.FindBy(1);
            Assert.NotNull(question);
            Assert.AreEqual(WorkbookVersion.v2004, question.Version);
            Assert.AreEqual(1, question.Number);
            Assert.AreEqual("Q1. A PS-1 form", question.Description);
            Assert.AreEqual("PS-1", question.Code);
            Assert.AreEqual("S", question.GearCode);
            Assert.AreEqual(Constraint.CorrectOrError, question.Constraint);
            Assert.NotNull(question.Category);
        }

        [Test]
        public void TestGetAllQuestions()
        {
            var questions = repo.All();
            Assert.NotNull(questions);
            foreach (var question in questions)
            {
                Assert.NotNull(question);
                Assert.NotNull(question.Description);
                Assert.NotNull(question.Code);
                Assert.NotNull(question.GearCode);
                Assert.NotNull(question.Constraint);
            }
        }

        [Test]
        public void TestGetPurseSeineQuestions()
        {
            var questions = repo.FilterBy(q => q.Code.StartsWith("PS-"));
            Assert.NotNull(questions);
            Assert.IsFalse(questions.Count() == 0);
            foreach (var question in questions)
            {
                Assert.NotNull(question);
                Assert.AreEqual("S", question.GearCode);
            }
        }
    }
}
