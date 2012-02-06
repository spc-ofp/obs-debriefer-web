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

    /// <summary>
    /// ViewModel for the header level information representing a debriefing.
    /// </summary>
    public class DebriefingHeaderViewModel
    {
        public static List<GearSelection> GearTypes = new List<GearSelection>()
        {
            new GearSelection() { Code = "L", Label = "Long line" },
            new GearSelection() { Code = "S", Label = "Purse seine" }
        };

        public DebriefingHeaderViewModel()
        {
            SectionStatusList = new List<SectionStatusViewModel>();
        }

        // One-way property used to notify display logic that this header is read-only
        public bool IsReadOnly { get; set; }

        // One-way property used to notify display logic that status can be updated to 'Closed'
        public bool IsCloseable { get; set; }
        
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets trip number.
        /// </summary>
        [Required]
        [Display(Name = "Trip Number")]
        public string TripNumber { get; set; }

        /// <summary>
        /// Gets or sets observer code.
        /// </summary>
        [Required]
        [Display(Name = "Observer")]
        public string ObserverCode { get; set; }

        [Required]
        [Display(Name = "Vessel")]
        public int VesselId { get; set; }

        /// <summary>
        /// Gets or sets vessel name
        /// </summary>
        public string VesselName { get; set; }

        [Required]
        [Display(Name = "Program Code")]
        public string ProgramCode { get; set; }

        [Required]
        [Display(Name = "Gear Code")]
        public string GearCode { get; set; }

        [Required]
        [Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }

        [Required]
        [Display(Name = "Departure Port")]
        public int DeparturePortId { get; set; }

        public string DeparturePort { get; set; }

        [Required]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }

        [Required]
        [Display(Name = "Return Port")]
        public int ReturnPortId { get; set; }

        public string ReturnPort { get; set; }

        [Required]
        [Display(Name = "Debriefer")]
        public string DebrieferCode { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string CountryCode { get; set; }

        [Required]
        [Display(Name = "Version")]
        public string Version { get; set; }

        public string Status { get; set; }

        public string Comments { get; set; }

        public string EnteredBy { get; set; }

        public DateTime? EnteredDate { get; set; }

        public bool GearOrVersionImpact { get; set; }

        /// <summary>
        /// Gets or sets the value of PreviousGearCode
        /// Use this for confirmation on the edit side.
        /// </summary>
        public string PreviousGearCode { get; set; }

        public string PreviousVersion { get; set; }

        public string PositiveActionResponse { get; set; }

        public IList<SectionStatusViewModel> SectionStatusList { get; protected set; }

        public class GearSelection
        {
            public string Code { get; set; }
            public string Label { get; set; }
        }
    }
}