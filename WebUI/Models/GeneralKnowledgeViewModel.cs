// -----------------------------------------------------------------------
// <copyright file="EvaluationViewModel.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// ViewModel for capturing the Random General Knowledge Test (RGKT)
    /// portion of a debriefing.
    /// </summary>
    public class GeneralKnowledgeViewModel
    {
        public string Correct { get; set; }
        public string Notes { get; set; }
    }
}