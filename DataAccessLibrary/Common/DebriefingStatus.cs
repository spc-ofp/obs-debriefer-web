// -----------------------------------------------------------------------
// <copyright file="DebriefingStatus.cs" company="Secretariat of the Pacific Community">
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
    /// Status of debriefing.
    /// </summary>
    public enum DebriefingStatus
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        Unknown = 0,

        /// <summary>
        /// Complete
        /// </summary>
        [Description("Complete")]
        Complete = 1,

        /// <summary>
        /// Incomplete
        /// </summary>
        [Description("Incomplete")]
        Incomplete = 2,

        /// <summary>
        /// Pending
        /// </summary>
        [Description("Pending")]
        Pending = 3,
    }
}
