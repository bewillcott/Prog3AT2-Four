/*
 *  File Name:   MainWindow.SessionEventHandlers.cs
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
 * Date: 30/10/2021
 * ****************************************************************
 */

namespace GUIClient
{
    using System.ComponentModel;

    public partial class MainWindow
    {
        /// <summary>
        /// Handles the PropertyChanged event of the Session.ChatSessionOpen property.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void ChatSessionOpen_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // TODO: Add code to Session_ChatSessionOpen_PropertyChanged(...)
        }

        /// <summary>
        /// Handles the PropertyChanged event of the Session.LoggedIn property.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void LoggedIn_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Session.LoggedIn)
            {
                CentreFrame.Content = new ChatPage(Session);
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of the Session.StatusText property.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void StatusText_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            statusTextBlock.Text = Session.StatusText;
        }
    }
}