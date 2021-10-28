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
    using System.Text;

    using static Common.Constants;

    public static class Server
    {
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
                int sessionNumber = 0;

                while (keepServerAlive)
                {
                    using (TcpClient clientSocket = serverSocket.AcceptTcpClient())
                    {
                        // wait, listen and accept connection
                        sessionNumber++;
                        String clientHostName = ((IPEndPoint)clientSocket.Client.RemoteEndPoint).Address.ToString(); // client name
                        int clientPortNumber = ((IPEndPoint)clientSocket.Client.RemoteEndPoint).Port; // port used

                        Log($"[{sessionNumber}] Connected from {clientHostName} on {clientPortNumber}");

                        try
                        {
                            // input stream from client
                            using (StreamReader inStream = new(clientSocket.GetStream()))
                            // output stream to client
                            using (StreamWriter outStream = new(clientSocket.GetStream()))
                            {
                                bool sessionOpen = true;

                                // Notify client of connection success.
                                String msg = $"[{sessionNumber}] You have connect to Chat server {VERSION}";
                                outStream.WriteLine(msg); // send a message to client

                                while (sessionOpen)
                                { // chatting loop
                                    String inLine = inStream.ReadLine(); // read a line from client
                                    Log($"[{sessionNumber}] Received from client: {inLine}");

                                    if (inLine == null)
                                    {
                                        Log($"[{sessionNumber}] Client disconnected uncleanly!");
                                        Log($"{LINE}\n");
                                        sessionOpen = false;
                                    }
                                    else
                                    {
                                        switch (inLine)
                                        {
                                            // if the client sends disconnect string, then stop
                                            case DISCONNECT_SESSION:
                                                {
                                                    Log($"[{sessionNumber}] Client closed session.");
                                                    Log($"{LINE}\n");
                                                    sessionOpen = false;
                                                    break;
                                                }

                                            // if the client sends terminate server string, then shutdown
                                            case TERMINATE_SERVER:
                                                {
                                                    Log($"[{sessionNumber}] Client Terminated Server!!!");
                                                    Log($"{DOUBLE_LINE}\n");
                                                    sessionOpen = false;

                                                    // Stop server
                                                    keepServerAlive = false;
                                                    break;
                                                }

                                            default:
                                                {
                                                    // Reply to client
                                                    String outLine = $"[{sessionNumber}] You said '{inLine}'";
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
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (serverSocket != null)
                    serverSocket.Stop();
            }
        }
    }
}