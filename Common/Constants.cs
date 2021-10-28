/*
 *  File Name:   Constants.cs
 *
 *  Project:     Common
 *
 *  Copyright (c) 2021 Bradley Willcott
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 * ****************************************************************
 * Name: Bradley Willcott
 * ID:   M198449
 * Date: 28/10/2021
 * ****************************************************************
 */

namespace Common
{
    using System;

    /// <summary>
    /// Constants is a utility class containing only common constants.
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The build date of the project.
        /// </summary>
        public const string BUILD_DATE = @"30 October 2021";

        /// <summary>
        /// Chat service disconnect string.
        /// </summary>
        public const String DISCONNECT_SESSION = @"-=quit=-";

        /// <summary>
        /// The Project title.
        /// </summary>
        public const string PRODUCT_TITLE = @"Prog3 AT2 Four";

        /// <summary>
        /// Defines the SERVER_NAME.
        /// </summary>
        public const String SERVER_NAME = @"localhost";

        /// <summary>
        /// SocketServer port number.
        /// </summary>
        public const int SERVER_PORT = 9010;

        /// <summary>
        /// Chat service server terminate string.
        /// </summary>
        public const String TERMINATE_SERVER = @"!**_Terminate_Server_**!";

        /// <summary>
        /// The Project version number.
        /// </summary>
        public const string VERSION = @"v1.0";

        /// <summary>
        /// Holds the double line.
        /// </summary>
        private static string doubleLine;

        /// <summary>
        /// Holds the single line.
        /// </summary>
        private static string line;

        /// <summary>
        /// Holds the title indent.
        /// </summary>
        private static string titleIndent;

        /// <summary>
        /// Gets the double line.
        /// </summary>
        public static string DOUBLE_LINE
        {
            get
            {
                if (doubleLine == null)
                {
                    doubleLine = new string('=', 80);
                }

                return doubleLine;
            }
        }

        /// <summary>
        /// Gets the single line.
        /// </summary>
        public static string LINE
        {
            get
            {
                if (line == null)
                {
                    line = new string('-', 80);
                }

                return line;
            }
        }

        /// <summary>
        /// Gets the title indent.
        /// </summary>
        public static string TITLE_INDENT
        {
            get
            {
                if (titleIndent == null)
                {
                    titleIndent = new string(' ', 20);
                }

                return titleIndent;
            }
        }

        /// <summary>
        /// Log messages to the standard console.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        /// <param name="args">The args <see cref="object[]"/>.</param>
        public static void Log(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}