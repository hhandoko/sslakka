// -----------------------------------------------------------------------
// <copyright file="IntegrationTestFixture.cs">
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

namespace Sslakka.Web.Tests.Fixtures
{
    using NUnit.Framework;
    using ServiceStack;

    /// <summary>
    /// Integration test fixture base class.
    /// </summary>
    public class IntegrationTestFixture
    {
        // Test application base URI
        const string BaseUri = "http://localhost:8081/";

        // Test application host instance
        ServiceStackHost appHost;

        /// <summary>
        /// Tests fixture set up.
        /// </summary>
        /// <returns>The fixture set up.</returns>
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            // Start your AppHost on Test Fixture setup
            appHost =
                new AppHost()
                    .Init()
                    .Start(BaseUri);
        }

        /// <summary>
        /// Tests fixture tear down.
        /// </summary>
        /// <returns>The fixture tear down.</returns>
        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Dispose it on tear down
            appHost.Dispose();
        }

    }
}
