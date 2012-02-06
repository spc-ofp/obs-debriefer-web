// -----------------------------------------------------------------------
// <copyright file="TestSimpleQuestion.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace WebUI.Tests
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
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    using NUnit.Framework;
    using WebUI.Models;
    
    [TestFixture]
    public class TestSimpleQuestion
    {
        [Test]
        public void TestRegularExpression()
        {
            string value = "Questions[2].Answer";
            Match m = SimpleQuestion.SearchTerm.Match(value);
            Assert.True(m.Success);
        }
        
        [Test]
        public void TestFormExtraction()
        {
            FormCollection form = new FormCollection();
            form.Add("Questions[2].Answer", "AnswerForQuestionTwo");
            form.Add("Questions[2].Notes", String.Empty);
            form.Add("Questions[4].Answer", "AnswerForQuestionFour");
            form.Add("Questions[4].Notes", "NotesForQuestionFour");

            IDictionary<int, SimpleQuestion> questions = SimpleQuestion.FromForm(form);
            Assert.NotNull(questions);
            Assert.False(0 == questions.Count);
            Assert.True(questions.ContainsKey(2));
            Assert.True(questions.ContainsKey(4));
            SimpleQuestion q2 = questions[2];
            Assert.NotNull(q2);
            Assert.AreEqual("AnswerForQuestionTwo", q2.Answer);
            Assert.IsTrue(String.IsNullOrEmpty(q2.Notes));
            SimpleQuestion q4 = questions[4];
            Assert.AreEqual("AnswerForQuestionFour", q4.Answer);
            Assert.AreEqual("NotesForQuestionFour", q4.Notes);
        }
    }
}