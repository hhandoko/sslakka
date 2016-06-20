// -----------------------------------------------------------------------
// <copyright file="AppHost.cs">
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

namespace Sslakka
{
    using Funq;
    using ServiceStack;
    using ServiceStack.Razor;

    using Sslakka.Web;

    /// <summary>
    /// Web application host.
    /// </summary>
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sslakka.Web.AppHost"/> class.
        /// </summary>
        public AppHost() : base("sslakka", typeof(AppHost).Assembly) { }

        /// <summary>
        /// Configure the specified container.
        /// </summary>
        /// <param name="container">Container.</param>
        public override void Configure(Container container)
        {
            Plugins.Add(new RazorFormat
            {
                LoadFromAssemblies = { typeof(WebProjectMarker).Assembly }
            });
        }
    }
}

