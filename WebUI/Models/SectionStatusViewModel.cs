// -----------------------------------------------------------------------
// <copyright file="DebriefingHeaderViewModel.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace WebUI.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    
    public class SectionStatusViewModel
    {
        public string Name { get; set; }
        public decimal PercentComplete { get; set; }
    }
}