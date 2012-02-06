// -----------------------------------------------------------------------
// <copyright file="ObserverProgram.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------
namespace Spc.Ofp.Debriefer.Dal.Common
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
    using System.ComponentModel;

    /// <summary>
    /// ObserverPrograms is an enumeration of the existing tuna fishing observer
    /// programs in the western central Pacific region.
    /// </summary>
    public enum ObserverProgram
    {
        /// <summary>
        /// ARTP Observer data
        /// </summary>
        [Description("ARTP Observer data")]
        AROB,

        /// <summary>
        /// American Samoa Observer Programme
        /// </summary>
        [Description("American Samoa Observer Programme")]
        ASOB,

        /// <summary>
        /// Australia Observer Programme
        /// </summary>
        [Description("Australia Observer Programme")]
        AUOB,

        /// <summary>
        /// Cook Islands Observer Programme
        /// </summary>
        [Description("Cook Islands Observer Programme")]
        CKOB,

        /// <summary>
        /// FSM Arrangement Observer Trips
        /// </summary>
        [Description("FSM Arrangement Observer Trips")]
        FAOB,

        /// <summary>
        /// Fiji Observer Programme
        /// </summary>
        [Description("Fiji Observer Programme")]
        FJOB,

        /// <summary>
        /// FSM Observer Programme
        /// </summary>
        [Description("FSM Observer Programme")]
        FMOB,

        /// <summary>
        /// Hawaii-NMFS Observer Programme
        /// </summary>
        [Description("Hawaii-NMFS Observer Programme")]
        HWOB,

        /// <summary>
        /// Kiribati Observer Programme
        /// </summary>
        [Description("Kiribati Observer Programme")]
        KIOB,

        /// <summary>
        /// Marshall Islands Observer Trip
        /// </summary>
        [Description("Marshall Islands Observer Trip")]
        MHOB,

        /// <summary>
        /// New Caledonia Observer Programme
        /// </summary>
        [Description("New Caledonia Observer Programme")]
        NCOB,

        /// <summary>
        /// Nauru Observer Trips
        /// </summary>
        [Description("Nauru Observer Trips")]
        NROB,

        /// <summary>
        /// Niue Observer Programme
        /// </summary>
        [Description("Niue Observer Programme")]
        NUOB,

        /// <summary>
        /// New Zealand Observer Programme
        /// </summary>
        [Description("New Zealand Observer Programme")]
        NZOB,

        /// <summary>
        /// French Polynesia Observer Programme
        /// </summary>
        [Description("French Polynesia Observer Programme")]
        PFOB,

        /// <summary>
        /// PNG Observer Programme
        /// </summary>
        [Description("PNG Observer Programme")]
        PGOB,

        /// <summary>
        /// Palau Observer Trips
        /// </summary>
        [Description("Palau Observer Trips")]
        PWOB,

        /// <summary>
        /// Solomon Islands Observer Progrogramme
        /// </summary>
        [Description("Solomon Islands Observer Progrogramme")]
        SBOB,

        /// <summary>
        /// SPC Observer Programme
        /// </summary>
        [Description("SPC Observer Programme")]
        SPOB,

        /// <summary>
        /// Tonga Observer Programme
        /// </summary>
        [Description("Tonga Observer Programme")]
        TOOB,

        /// <summary>
        /// US MLT Observer Programme
        /// </summary>
        [Description("US MLT Observer Programme")]
        TTOB,

        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        UNOB,

        /// <summary>
        /// Vanuatu Observer Programme
        /// </summary>
        [Description("Vanuatu Observer Programme")]
        VUOB,

        /// <summary>
        /// Wallis & Futuna Observer Programme
        /// </summary>
        [Description("Wallis & Futuna Observer Programme")]
        WFOB,

        /// <summary>
        /// Samoa Observer Programme
        /// </summary>
        [Description("Samoa Observer Programme")]
        WSOB
    }
}
