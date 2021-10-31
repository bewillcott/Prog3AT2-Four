/*
 *  File Name:   MainWindow.xaml.cs
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
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Defines the blankPage.
        /// </summary>
        private static readonly BlankPage blankPage = new BlankPage();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            SetTitle();
            CentreFrame.Content = blankPage;
            SetStatusText(null);
        }

        ///// <summary>
        ///// Gets the ChatPage.
        ///// </summary>
        //public ChatPage ChatPage { get; private set; }

        ///// <summary>
        ///// Gets the NewAccountPage.
        ///// </summary>
        //public NewAccountPage NewAccountPage { get; private set; }

        ///// <summary>
        ///// Gets the LoginPage.
        ///// </summary>
        //public LoginPage LoginPage { get; private set; }

        /// <summary>
        /// Gets or sets the Session.
        /// </summary>
        public Session Session { get; set; }
    }
}