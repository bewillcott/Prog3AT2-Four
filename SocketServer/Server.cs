/*
 *  File Name:   Server.cs
 *
 *  Project:     SocketServer
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

namespace SocketServer
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;

    using static Common.Constants;
    using static Common.SessionConstants;

    /// <summary>
    /// Defines the <see cref="Server" />.
    /// </summary>
    public static class Server
    {
        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        private static void Main(string[] args)
        {
            IPAddress ipAddress = Dns.GetHostEntry(SERVER_NAME).AddressList[0];
            IPEndPoint endPoint = new(ipAddress, SERVER_PORT);
            TcpListener serverSocket = null;

            try
            {
                // Create a socket that will use TCP protocol
                serverSocket = new(endPoint);

                serverSocket.Start();

                Log($"\n{DOUBLE_LINE}");
                Log($"{TITLE_INDENT}Java3 AT2 Four - Socket Server ({VERSION})");
                Log($"{DOUBLE_LINE}\n");
                Log($"Server is listening on port {((IPEndPoint)serverSocket.Server.LocalEndPoint).Port.ToString()}");
                Log($"{LINE}\n");

                bool keepServerAlive = true;

                while (keepServerAlive)
                {
                    // wait, listen and accept connection
                    using (TcpClient clientSocket = serverSocket.AcceptTcpClient())
                    {
                        SessionState sessionState = new();
                        sessionState.ClientHostName = ((IPEndPoint)clientSocket.Client.RemoteEndPoint).Address.ToString(); // client name
                        sessionState.ClientPortNumber = ((IPEndPoint)clientSocket.Client.RemoteEndPoint).Port; // port used

                        Log($"[{sessionState.SessionId}] Connected from {sessionState.ClientHostName} on {sessionState.ClientPortNumber}");

                        try
                        {
                            // input stream from client
                            using (StreamReader inStream = new(clientSocket.GetStream()))
                            // output stream to client
                            using (StreamWriter outStream = new(clientSocket.GetStream()))
                            {
                                // Get Client request string
                                string input = inStream.ReadLine();

                                string[] request = input.Split(':');

                                switch (request[0])
                                {
                                    case LoginRequest:
                                        {
                                            // Process Login request
                                            if (sessionState.Username == null)
                                            {
                                                if (request.Length == 3)
                                                {
                                                    if (ValidatePassword(sessionState, request[1], request[2]))
                                                    {
                                                        // Logged in!
                                                        sessionState.Message = LoginOK;
                                                    }
                                                    else
                                                    {
                                                        // Password is wrong
                                                        sessionState.Message = LoginFailed;
                                                    }
                                                }
                                                else
                                                {
                                                    // Either username &/or password missing
                                                    sessionState.Message = BadRequest;
                                                }
                                            }
                                            else
                                            {
                                                // Already logged in
                                                sessionState.Message = InvalidRequest;
                                            }

                                            break;
                                        }

                                    case ChatRequest:
                                        {
                                            // Setup for Chat session
                                            if (sessionState.CanOpenChat())
                                            {
                                                // Chat session is Open!
                                                sessionState.ChatOpen = true;

                                                // Notify client of connection success.
                                                String msg = $":[{sessionState.SessionId}] "
                                                    + $"You have connected to Chat server {VERSION}";
                                                sessionState.Message = ChatOK + msg;
                                            }
                                            else
                                            {
                                                // Sorry, can't let you in
                                                sessionState.Message = InvalidRequest;
                                            }

                                            break;
                                        }

                                    default:
                                        {
                                            // Unknown request
                                            sessionState.Message = InvalidRequest;
                                            break;
                                        }
                                }

                                // Send message to Client
                                outStream.WriteLine(sessionState.Message);
                                Log(sessionState.Message);

                                // Chat Session
                                if (sessionState.ChatOpen)
                                {
                                    // chatting loop
                                    while (sessionState.ChatOpen)
                                    {
                                        String inLine = inStream.ReadLine(); // read a line from client
                                        Log($"[{sessionState.SessionId}] Received from client: {inLine}");

                                        if (inLine == null)
                                        {
                                            Log($"[{sessionState.SessionId}] Client disconnected uncleanly!");
                                            Log($"{LINE}\n");
                                            sessionState.ChatOpen = false;
                                        }
                                        else
                                        {
                                            if (inLine.Equals(ChatClose))
                                            {
                                                Log($"[{sessionState.SessionId}] Client closed session.");
                                                Log($"{LINE}\n");
                                                sessionState.ChatOpen = false;
                                                break;
                                            }
                                            else
                                            {
                                                // Reply to client
                                                String outLine = $"[{sessionState.SessionId}] You said '{inLine}'";
                                                outStream.WriteLine(outLine); // send a message to client
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log(ex.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
            }
            finally
            {
                if (serverSocket != null)
                    serverSocket.Stop();
            }
        }

        /// <summary>
        /// The ValidatePassword.
        /// </summary>
        /// <param name="sessionState">The sessionState<see cref="SessionState"/>.</param>
        /// <param name="username">The username <see cref="string"/>.</param>
        /// <param name="password">The password <see cref="string"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private static bool ValidatePassword(SessionState sessionState, string username, string password)
        {
            // TODO: Redo code to actually check the password is valid
            sessionState.Username = username;
            sessionState.PasswordValid = password != null;
            return true;
        }
    }
}