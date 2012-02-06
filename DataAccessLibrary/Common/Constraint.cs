// -----------------------------------------------------------------------
// <copyright file="Constraint.cs" company="Secretariat of the Pacific Community">
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
    /// Possible constraints on the answer.
    /// </summary>
    public enum Constraint
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        Unknown = 0,

        /// <summary>
        /// Default: Cc/Inc/InR/Er/ErR/X
        /// </summary>
        [Description("Default")]
        Default = 1,

        /// <summary>
        /// WrittenReport: Wk/Gd/Vg/Exc
        /// </summary>
        [Description("Written Report")]
        WrittenReport = 2,

        /// <summary>
        /// DefaultWithDne: Cc/Inc/InR/Er/ErR/X/DnE
        /// </summary>
        [Description("Default With DnE")]
        DefaultWithDne = 3,

        /// <summary>
        /// YesNo: Y/N
        /// </summary>
        [Description("Yes No")]
        YesNo = 4,

        /// <summary>
        /// CorrectOrError: Cc/Er
        /// </summary>
        [Description("Correct Or Error")]
        CorrectOrError = 5,

        /// <summary>
        /// FreeText: Anything but typically just a numeric value for year form was published
        /// </summary>
        [Description("Free Text")]
        FreeText = 6,
    }
}
