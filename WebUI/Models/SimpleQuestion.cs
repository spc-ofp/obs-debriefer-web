// -----------------------------------------------------------------------
// <copyright file="SimpleQuestion.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace WebUI.Models
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
    using System.Text.RegularExpressions;
    using System.Web.Mvc;
    
    /// <summary>
    /// SimpleQuestion is used to convert FormCollection data
    /// into something that can be pushed into an EvaluationSectionViewModel 
    /// </summary>
    public class SimpleQuestion
    {
        public static Regex SearchTerm = new Regex(@"Questions\[(\d+)\]", RegexOptions.IgnoreCase);
        
        public int Number { get; set; }
        public string Answer { get; set; }
        public string Notes { get; set; }

        public static IDictionary<int, SimpleQuestion> FromForm(FormCollection form)
        {
            IDictionary<int, SimpleQuestion> questions = new Dictionary<int, SimpleQuestion>();
            if (null != form)
            {
                var numberQuery =
                    from string key in form.Keys
                    let match = SearchTerm.Match(key)
                    where match.Success
                    select match.Groups[1].Value;

                foreach (var number in numberQuery.Distinct())
                {
                    System.Diagnostics.Debug.WriteLine("Found number " + number);
                    int questionNumber = Int32.Parse(number);
                    string keyPrefix = String.Format("Questions[{0}].", number);
                    string noteKey = keyPrefix + "Notes";
                    string answerKey = keyPrefix + "Answer";
                    SimpleQuestion question = new SimpleQuestion()
                    {
                        Number = questionNumber,
                        Answer = form[answerKey],
                        Notes = form[noteKey]
                    };
                    questions.Add(questionNumber, question);
                }
            }
            return questions;
        }
    }
}