// -----------------------------------------------------------------------
// <copyright file="Gear.cs" company="Secretariat of the Pacific Community">
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
    /// Gear is an enumeration of the existing tuna fishing gear types
    /// in the western central Pacific region.
    /// </summary>
    public enum Gear
    {
        /// <summary>
        /// Bunker
        /// </summary>
        [Description("Bunker")]
        B,

        /// <summary>
        /// Carrier
        /// </summary>
        [Description("Carrier")]
        C,

        /// <summary>
        /// Live fish boat
        /// </summary>
        [Description("Live fish boat")]
        F,

        /// <summary>
        /// Group seine
        /// </summary>
        [Description("Group seine")]
        G,

        /// <summary>
        /// Handline
        /// </summary>
        [Description("Handline")]
        H,

        /// <summary>
        /// Longline
        /// </summary>
        [Description("Longline")]
        L,

        /// <summary>
        /// Gillnet
        /// </summary>
        [Description("Gillnet")]
        N,

        /// <summary>
        /// Other
        /// </summary>
        [Description("Other")]
        O,

        /// <summary>
        /// Pole-and-line
        /// </summary>
        [Description("Pole-and-line")]
        P,

        /// <summary>
        /// Research / Training vessel
        /// </summary>
        [Description("Research / Training vessel")]
        R,

        /// <summary>
        /// Purse seine
        /// </summary>
        [Description("Purse seine")]
        S,

        /// <summary>
        /// Troll
        /// </summary>
        [Description("Troll")]
        T,

        /// <summary>
        /// Light boat
        /// </summary>
        [Description("Light boat")]
        V,

        /// <summary>
        /// Fish processor
        /// </summary>
        [Description("Fish processor")]
        X,
    }
}
