/*
 *  File Name:   MainWindow.EventHandlers.cs
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
    using System.ComponentModel;
    using System.Globalization;
    using System.IO;
    using System.Windows;
    using System.Windows.Input;

    using Microsoft.Win32;

    /// <summary>
    /// Defines the <see cref="MainWindow" />.
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// The AboutCommand_CanExecute.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="CanExecuteRoutedEventArgs"/>.</param>
        private void AboutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void LoginCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void LoginCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            ShowChatPage();
        }

        private void LogoutCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void LogoutCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            CentreFrame.Content = blankPage;
            ChatPage.Dispose();
            ChatPage = null;
        }

        /// <summary>
        /// The AboutCommand_Executed.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="ExecutedRoutedEventArgs"/>.</param>
        private void AboutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // Display the About dialog
            AboutWindow aboutWindow = new();
            aboutWindow.Owner = this;
            aboutWindow.ShowDialog();

            e.Handled = true;
        }

        /// <summary>
        /// The ExitCommand_CanExecute.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="CanExecuteRoutedEventArgs"/>.</param>
        private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// The ExitCommand_Executed.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="ExecutedRoutedEventArgs"/>.</param>
        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
            e.Handled = true;
        }

        /// <summary>
        /// The Window_Closing.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="CancelEventArgs"/>.</param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                if (ChatPage != null)
                {
                    ChatPage.Dispose();
                    ChatPage = null;
                }

                Application.Current.Shutdown();
            }
        }
    }
}