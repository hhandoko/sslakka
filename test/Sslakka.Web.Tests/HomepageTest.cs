// -----------------------------------------------------------------------
// <copyright file="HomepageTest.cs">
//   Copyright (c) 2016 sslakka contributors
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// -----------------------------------------------------------------------

namespace Sslakka.Web.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Homepage acceptance test.
    /// </summary>
    [TestFixture("firefox", "46", "OSX")]
    public class HomepageTest : AcceptanceTestFixture
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sslakka.Web.Tests.HomepageTest"/> class.
        /// </summary>
        /// <param name="browser">Browser type.</param>
        /// <param name="version">Browser version.</param>
        /// <param name="os">Operating System type.</param>
        /// <param name="deviceName">Device name.</param>
        /// <param name="deviceOrientation">Device orientation.</param>
        public HomepageTest(string browser, string version, string os)
            : base(browser, version, os) { }

        /// <summary>
        /// Visitors the can view the homepage.
        /// </summary>
        [Test]
        public void visitor_can_view_homepage()
        {
            GoTo(Homepage);

            StringAssert.Contains("sslakka", Homepage.Title());
        }
    }
}