/*
 *  File Name:   CustomCommands.cs
 *
 *  Project:     GUI_Client
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
 * Date: 27/10/2021
 * ****************************************************************
 */

namespace GUIClient
{
    using System.Windows.Input;

    /// <summary>
    /// Defines the <see cref="CustomCommands" />.
    /// </summary>
    public static class CustomCommands
    {
        /// <summary>
        /// Defines the About.
        /// </summary>
        public static readonly RoutedUICommand About =
            new(@"_About", nameof(About), typeof(CustomCommands));

        /// <summary>
        /// Defines the Add.
        /// </summary>
        public static readonly RoutedUICommand Add =
            new(
                        @"_Add",
                        nameof(Add),
                        typeof(CustomCommands),
                        new InputGestureCollection {
                        new KeyGesture(Key.A, ModifierKeys.Control)});

        /// <summary>
        /// Defines the Edit.
        /// </summary>
        public static readonly RoutedUICommand Edit =
            new(
                        @"_Edit",
                        nameof(Edit),
                        typeof(CustomCommands),
                        new InputGestureCollection {
                        new KeyGesture(Key.E, ModifierKeys.Control)});

        /// <summary>
        /// Defines the Exit.
        /// </summary>
        public static readonly RoutedUICommand Exit =
            new(
                        @"E_xit",
                        nameof(Exit),
                        typeof(CustomCommands),
                        new InputGestureCollection {
                        new KeyGesture(Key.F4, ModifierKeys.Alt)});
    }
}