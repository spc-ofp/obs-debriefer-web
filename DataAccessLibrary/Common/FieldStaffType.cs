// -----------------------------------------------------------------------
// <copyright file="FieldStaffType.cs" company="Secretariat of the Pacific Community">
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
    /// ObserverPrograms is an enumeration of the common roles present in observer
    /// programs in the western central Pacific region.
    /// </summary>
    public enum FieldStaffType
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        Unknown = 0,

        /// <summary>
        /// Senior Observer
        /// </summary>
        [Description("Senior Observer")]
        SeniorObserver = 1,

        /// <summary>
        /// Fishery Officer
        /// </summary>
        [Description("Fishery Officer")]
        FisheryOfficer = 2,

        /// <summary>
        /// Port Sampler
        /// </summary>
        [Description("Port Sampler")]
        PortSampler = 3,

        /// <summary>
        /// Observer
        /// </summary>
        [Description("Observer")]
        Observer = 4,

        /// <summary>
        /// Agent
        /// </summary>
        [Description("Agent")]
        Agent = 5,

        /// <summary>
        /// Captain
        /// </summary>
        [Description("Captain")]
        Captain = 6,

        /// <summary>
        /// Port Sampler / Observer
        /// </summary>
        [Description("Port Sampler / Observer")]
        PortSamplerObserver = 7,

        /// <summary>
        /// Observer / Port Sampling Coordinator
        /// </summary>
        [Description("Observer / Port Sampling Coordinator")]
        ObserverPortSamplingCoordinator = 8,

        /// <summary>
        /// Observer / Port Sampling Supervisor
        /// </summary>
        [Description("Observer / Port Sampling Supervisor")]
        ObserverPortSamplingSupervisor = 9,
    }
}
