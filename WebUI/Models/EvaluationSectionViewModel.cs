// -----------------------------------------------------------------------
// <copyright file="EvaluationSectionViewModel.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace WebUI.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class EvaluationSectionViewModel
    {
        public EvaluationSectionViewModel()
        {
            this.Categories = new List<EvaluationCategoryViewModel>();
        }

        public EvaluationSectionViewModel(string formName)
        {
            this.FormName = formName;
            this.Categories = new List<EvaluationCategoryViewModel>();
        }
        
        public string FormName { get; set; }
        public IList<EvaluationCategoryViewModel> Categories { get; set; }
    }
}