/*
 *  File Name:   MainWindow.Functions.cs
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
    using static Common.Constants;

    /// <summary>
    /// Defines the <see cref="MainWindow" />.
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Set the Status line text.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public void SetStatusText(string message)
        {
            statusTextBlock.Text = message != null ? message : string.Empty;
        }

        /// <summary>
        /// Set the Window Title.
        /// </summary>
        private void SetTitle()
        {
            this.Title = ProductTitle;
        }

        private void ShowBlankPage()
        {
            CentreFrame.Content = blankPage;
        }

        /// <summary>
        /// Show the ChatPage.
        /// </summary>
        private void ShowChatPage()
        {
            CentreFrame.Content = new ChatPage(Session);
            CentreFrame.Content = null;
        }

        /// <summary>
        /// Show the ChatPage.
        /// </summary>
        private void ShowNewAccountPage()
        {
            CentreFrame.Content = new NewAccountPage(Session);
        }

        /// <summary>
        /// Show the ChatPage.
        /// </summary>
        private void ShowLoginPage()
        {
            CentreFrame.Content = new LoginPage(Session);
        }
    }
}