// -----------------------------------------------------------------------
// <copyright file="AcceptanceTestFixture.cs">
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
    using System;
    using System.Diagnostics;
    using System.IO;

    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Remote;

    using Sslakka.Web.Tests.PageObjects;

    /// <summary>
    /// Acceptance test fixture base class.
    /// </summary>
    public class AcceptanceTestFixture
    {
        /// <summary>
        /// The name of the application.
        /// </summary>
        private const string ApplicationName = "Sslakka";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sslakka.Web.Tests.AcceptanceTestFixture"/> class.
        /// </summary>
        /// <param name="browser">Browser type.</param>
        /// <param name="version">Browser version.</param>
        /// <param name="os">OS type.</param>
        public AcceptanceTestFixture(string browser, string version, string os)
        {
            this.Browser = browser;
            this.Version = version;
            this.OS = os;
        }

        /// <summary>
        /// Gets the Selenium driver.
        /// </summary>
        /// <value>The Selenium driver.</value>
        public IWebDriver Driver { get; private set; }

        /// <summary>
        /// Gets the browser type.
        /// </summary>
        /// <value>The browser type.</value>
        public string Browser { get; private set; }

        /// <summary>
        /// Gets the browser version.
        /// </summary>
        /// <value>The browser version.</value>
        public string Version { get; private set; }

        /// <summary>
        /// Gets the OS type.
        /// </summary>
        /// <value>The OS type.</value>
        public string OS { get; private set; }

        /// <summary>
        /// Gets or sets the homepage page object.
        /// </summary>
        /// <value>The homepage page object.</value>
        public Homepage Homepage { get; set; }

        /// <summary>
        /// Gets or sets the web process.
        /// </summary>
        /// <value>The web process.</value>
        private Process WebProcess { get; set; }

        /// <summary>
        /// Gos to a page.
        /// </summary>
        /// <returns>The destination page.</returns>
        /// <param name="page">Page.</param>
        public void GoTo(IPage page)
        {
            Driver.Navigate().GoToUrl(page.Url);
        }

        /// <summary>
        /// Initialise the test.
        /// </summary>
        [SetUp]
        public void Init()
        {
            var caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, Browser);
            caps.SetCapability(CapabilityType.Version, Version);
            caps.SetCapability(CapabilityType.Platform, OS);
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            // TODO: Setup RemoteWebDriver for remote testing
            // TODO: Switch to PhantomJs driver for local testing
            Driver = new FirefoxDriver();

            // Instantiate page objects
            Homepage = new Homepage(Driver);
        }

        /// <summary>
        /// Clean up the test.
        /// </summary>
        /// <returns>The up.</returns>
        [TearDown]
        public void CleanUp()
        {
            // Terminates the (remote) web driver session
            Driver.Quit();
        }

        /// <summary>
        /// Tests fixture set up.
        /// </summary>
        /// <returns>The fixture set up.</returns>
        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            // Start the web server on Test Fixture setup
            StartWebServer();
        }

        /// <summary>
        /// Tests fixture tear down.
        /// </summary>
        /// <returns>The fixture tear down.</returns>
        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            // Ensure web server is stopped
            if (!WebProcess.HasExited)
            {
                WebProcess.Kill();
            }
        }

        /// <summary>
        /// Starts the web server.
        /// </summary>
        /// <returns>The web server.</returns>
        private void StartWebServer()
        {
            var applicationPath = GetApplicationPath();

            // Start the web server process
            WebProcess = new Process();
            WebProcess.StartInfo.FileName = $"{applicationPath}{ApplicationName}.exe";
            // FIXME: Additional args does not work
            //WebProcess.StartInfo.Arguments = "http://*:8081";
            WebProcess.Start();
        }

        /// <summary>
        /// Gets the application path.
        /// </summary>
        /// <returns>The application path.</returns>
        protected virtual string GetApplicationPath()
        {
            // TODO: Refactor
            // Traverse up to the `*.sln` directory
            var solutionFolder =
                Path.GetDirectoryName(                 // "/"
                    Path.GetDirectoryName(             // "/test/"
                        Path.GetDirectoryName(         // "/test/Sslakka.Web.Tests/"
                            Path.GetDirectoryName(     // "/test/Sslakka.Web.Tests/bin/"
                                Path.GetDirectoryName( // "/test/Sslakka.Web.Tests/bin/Debug/"
                                    AppDomain.CurrentDomain.BaseDirectory
                                )
                            )
                        )
                    )
                );
            return Path.Combine(solutionFolder, $"src/{ApplicationName}/bin/Debug/");
        }
    }
}

