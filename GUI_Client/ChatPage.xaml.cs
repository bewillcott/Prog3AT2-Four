/*
 *  File Name:   ChatPage.xaml.cs
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
 * Date: 28/10/2021
 * ****************************************************************
 */

namespace GUIClient
{
    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Windows;
    using System.Windows.Controls;

    using static Common.Constants;

    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : Page, IDisposable
    {
        private TcpClient clientSocket;
        private bool disposed;
        private MainWindow mainWindow = null;
        private StreamReader inStream = null;
        private StreamWriter outStream = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatPage"/> class.
        /// </summary>
        public ChatPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            clientSocket = new();
            clientSocket.Connect(SERVER_NAME, SERVER_PORT);

            // input stream from client
            inStream = new(clientSocket.GetStream());
            // output stream to client
            outStream = new(clientSocket.GetStream());

            mainWindow.SetStatusText(@"Client Socket Program - Server Connected ...");
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ChatPage"/> class.
        /// </summary>
        ~ChatPage()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                // Disconnect from Server
                outStream.WriteLine(DISCONNECT_SESSION);
                outStream.Flush();
                outStream.Close();
                outStream.Dispose();

                inStream.Close();
                inStream.Dispose();

                // Cleanup
                clientSocket.Close();
                clientSocket.Dispose();
                disposed = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the sendButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}