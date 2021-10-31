/*
 *  File Name:   NewAccountPage.xaml.cs
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
 * Date: 29/10/2021
 * ****************************************************************
 */

namespace GUIClient
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for NewAccountPage.xaml
    /// </summary>
    public partial class NewAccountPage : Page
    {
        private Session session;

        public NewAccountPage(Session session)
        {
            InitializeComponent();
            this.session = session;
        }

        /// <summary>
        /// Handles the Click event of the ResetButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            usernameTextBox.Clear();
            firstPasswordBox.Clear();
            secondPasswordBox.Clear();
        }

        /// <summary>
        /// Handles the Click event of the SubmitButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            session.NewAccount(usernameTextBox.Text, firstPasswordBox.Password);
        }
    }
}