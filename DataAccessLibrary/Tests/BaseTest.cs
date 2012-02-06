// -----------------------------------------------------------------------
// <copyright file="BaseTest.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2011 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.Debriefer.Dal.Tests
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
    using NUnit.Framework;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public abstract class BaseTest
    {
        [TestFixtureSetUp]
        public static void Init()
        {
            var session = DebriefDataService.GetSession();
            session.Close();
        }

        [TestFixtureTearDown]
        public static void Dispose()
        {
            DebriefDataService.Dispose();
        }
    }
}
