// -----------------------------------------------------------------------
// <copyright file="EvaluationCategoryViewModel.cs" company="Secretariat of the Pacific Community">
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
    /// ViewModel for a category debriefing.  A category
    /// collects 1 or more associated questions in a given form.
    /// A category can also have a GeneralKnowledgeViewModel.
    /// </summary>
    public class EvaluationCategoryViewModel
    {
        public EvaluationCategoryViewModel()
        {
            this.Questions = new List<EvaluationQuestionViewModel>();
        }

        public EvaluationCategoryViewModel(string title)
        {
            this.Title = title;
            this.Questions = new List<EvaluationQuestionViewModel>();
        }
        
        public string Title { get; set; }
        public IList<EvaluationQuestionViewModel> Questions { get; set; }
        public GeneralKnowledgeViewModel Rgkt { get; set; }
        public bool HasDidNotEncounter { get; set; }
    }
}