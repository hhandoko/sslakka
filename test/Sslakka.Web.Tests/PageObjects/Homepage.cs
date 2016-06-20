// -----------------------------------------------------------------------
// <copyright file="Homepage.cs">
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

namespace Sslakka.Web.Tests.PageObjects
{
    using OpenQA.Selenium;

    /// <summary>
    /// Homepage test page object.
    /// </summary>
    public class Homepage : IPage
    {
        /// <summary>
        /// The default base URL.
        /// </summary>
        private const string DefaultBaseUrl = "http://localhost:8080";

        /// <summary>
        /// The default homepage base path.
        /// </summary>
        private const string DefaultBasePath = "/";

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sslakka.Web.Tests.PageObjects.Homepage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver.</param>
        public Homepage(IWebDriver driver) : this(driver, DefaultBaseUrl) {}

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sslakka.Web.Tests.PageObjects.Homepage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver.</param>
        /// <param name="baseUrl">Base URL.</param>
        public Homepage(IWebDriver driver, string baseUrl)
        {
            this.Driver = driver;
            this.BaseUrl = baseUrl;
            this.Url = $"{DefaultBaseUrl}{DefaultBasePath}";
        }

        /// <summary>
        /// Gets or sets the page URL.
        /// </summary>
        /// <value>The page URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets the Selenium driver.
        /// </summary>
        /// <value>The Selenium driver.</value>
        private IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>The base URL.</value>
        private string BaseUrl { get; set; }

        /// <summary>
        /// The page title.
        /// </summary>
        public string Title()
        {
            return Driver.Title;
        }
    }
}

