// -----------------------------------------------------------------------
// <copyright file="Program.cs">
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

namespace Sslakka.Web
{
    using System;

    using ServiceStack.Text;

    /// <summary>
    /// Web server main program (console app self-host).
    /// </summary>
    class Program
    {
        /// <summary>
        /// Web application main method (entry point).
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            // Starts the web server on port 8080 by default, or
            // whatever the user configured via parameters.
            var listeningOn = args.Length == 0 ? "http://*:8080/" : args[0];
            var appHost =
                new AppHost()
                    .Init()
                    .Start(listeningOn);

            // Prompt to show started / running web server status
            PrintPrompt(listeningOn);

            // Run web server indefinitely (until terminated)
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }

        /// <summary>
        /// Print the web application banner and running server details.
        /// </summary>
        /// <param name="listeningOn">The HTTP address and port web server is listening on.</param>
        private static void PrintPrompt(string listeningOn)
        {
            // Clear the screen and print banner :)
            Console.Clear();

            $"                                                         ".Print();
            $"                 .__          __    __                   ".Print();
            $"     ______ _____|  | _____  |  | _|  | _______          ".Print();
            $"    /  ___//  ___/  | \\__  \\ |  |/ /  |/ /\\__  \\     ".Print();
            $"    \\___ \\ \\___ \\|  |__/ __ \\|    <|    <  / __ \\_ ".Print();
            $"   /____  >____  >____(____  /__|_ \\__|_ \\(____  /     ".Print();
            $"        \\/     \\/          \\/     \\/    \\/     \\/  ".Print();
            $"                                                         ".Print();
            $"                                                         ".Print();
            $"      ServiceStack self-host web server:                 ".Print();
            $"          Started at   - {DateTime.Now}                  ".Print();
            $"          Listening on - {listeningOn}                   ".Print();
            $"                                                         ".Print();
            $"                                                         ".Print();
            $" ┌─────────────────────────────────────────────────┐      ".Print();
            $" │ Visit the following GitHub repository for docs, │      ".Print();
            $" │   roadmap, source code, and much, much more:    │      ".Print();
            $" │                                                 │      ".Print();
            $" │       https://github.com/hhandoko/sslakka       │      ".Print();
            $" └─────────────────────────────────────────────────┘      ".Print();
            $"                                                         ".Print();
            $"                                                         ".Print();
            $"  Made with ❤ in Singapore. Type [Ctrl+C] to quit.        ".Print();
            $"                                                         ".Print();
        }
    }
}
