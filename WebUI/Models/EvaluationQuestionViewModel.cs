// -----------------------------------------------------------------------
// <copyright file="EvaluationQuestionViewModel.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Spc.Ofp.Debriefer.Dal.Common;

    /// <summary>
    /// ViewModel for a single question.
    /// </summary>
    public class EvaluationQuestionViewModel
    {
        /// <summary>
        /// Get or set the question number as displayed on the debriefing form
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Get or set the question text as displayed on the debriefing form
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Get or set the answer to the question.
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Get or set the default answer for the question.
        /// </summary>
        public string DefaultAnswer { get; set; }

        /// <summary>
        /// Get or set the constraints on the answer.
        /// </summary>
        public Constraint AnswerConstraints { get; set; }

        /// <summary>
        /// Get or set the associated notes for this answer.
        /// </summary>
        public string Notes { get; set; }
    }
}