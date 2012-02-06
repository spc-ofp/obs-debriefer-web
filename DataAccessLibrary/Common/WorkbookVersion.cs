// -----------------------------------------------------------------------
// <copyright file="WorkbookVersion.cs" company="Secretariat of the Pacific Community">
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
    /// Version is an enumeration of the different iterations of observer forms.
    /// </summary>
    public enum WorkbookVersion
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        Unknown = 0,
        
        /// <summary>
        /// 1996
        /// </summary>
        [Description("1996")]
        v1996 = 115,

        /// <summary>
        /// 1998
        /// </summary>
        [Description("1998")]
        v1998 = 114,

        /// <summary>
        /// 2000
        /// </summary>
        [Description("2000")]
        v2000 = 113,

        /// <summary>
        /// 2001
        /// </summary>
        [Description("2001")]
        v2001 = 116,

        /// <summary>
        /// 2002
        /// </summary>
        [Description("2002")]
        v2002 = 112,

        /// <summary>
        /// 2004
        /// </summary>
        [Description("2004")]
        v2004 = 87,

        /// <summary>
        /// 2007
        /// </summary>
        [Description("2007")]
        v2007 = 111,
    }
}
