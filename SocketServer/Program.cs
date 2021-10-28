/*
 *  File Name:   Program.cs
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

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        private void StartServer()
        {
            IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
            IPEndPoint endPoint = new(ipAddress, SERVER_PORT);
            TcpListener serverSocket = null;

            try
            {
                // Create a socket that will use TCP protocol
                serverSocket = new(endPoint);

                // Specify how many requests a Socket can listen before it gives Server busy response.
                // We will listen 10 requests at a time
                serverSocket.Server.Listen(10);
                serverSocket.Start();

                Log("\n%1$s", DOUBLE_LINE);
                Log("%1$sJava3 AT2 Four - Socket Server (%2$s)", TITLE_INDENT, VERSION);
                Log("%1$s\n", DOUBLE_LINE);
                Log("Server is listening on port #%1$d", ((IPEndPoint)serverSocket.Server.LocalEndPoint).Port.ToString());
                Log("%1$s\n", LINE);

                bool keepServerAlive = true;
                int sessionNumber = 0;

                while (keepServerAlive)
                {
                    using (TcpClient clientSocket = serverSocket.AcceptTcpClient())
                    {
                        // wait, listen and accept connection
                        sessionNumber++;
                        String clientHostName = ((IPEndPoint)serverSocket.Server.RemoteEndPoint).Address.ToString(); // client name
                        int clientPortNumber = ((IPEndPoint)serverSocket.Server.RemoteEndPoint).Port; // port used

                        Log("[%1$d] Connected from %2$s on #%3$d", sessionNumber, clientHostName, clientPortNumber);

                        try
                        {
                            // input stream from client
                            using (StreamReader inStream = new(clientSocket.GetStream()))
                            // output stream to client
                            using (StreamWriter outStream = new(clientSocket.GetStream()))
                            {
                                bool sessionOpen = true;

                                // Notify client of connection success.
                                String msg = "[" + sessionNumber + "] You have connect to Chat server " + VERSION + "";
                                outStream.WriteLine(msg); // send a message to client

                                while (sessionOpen)
                                { // chatting loop
                                    String inLine = inStream.ReadLine(); // read a line from client
                                    Log("[%1$d] Received from client: %2$s", sessionNumber, inLine);

                                    if (inLine == null)
                                    {
                                        Log("[%1$d] Client disconnected uncleanly!", sessionNumber);
                                        Log("%1$s\n", LINE);
                                        sessionOpen = false;
                                    }
                                    else
                                    {
                                        switch (inLine)
                                        {
                                            // if the client sends disconnect string, then stop
                                            case DISCONNECT_SESSION:
                                                {
                                                    Log("[%1$d] Client closed session.", sessionNumber);
                                                    Log("%1$s\n", LINE);
                                                    sessionOpen = false;
                                                    break;
                                                }

                                            // if the client sends terminate server string, then shutdown
                                            case TERMINATE_SERVER:
                                                {
                                                    Log("[%1$d] Client Terminated Server!!!", sessionNumber);
                                                    Log("%1$s\n", DOUBLE_LINE);
                                                    sessionOpen = false;

                                                    // Stop server
                                                    keepServerAlive = false;
                                                    break;
                                                }

                                            default:
                                                {
                                                    break;
                                                }
                                        }

                                        // Reply to client
                                        String outLine = "[" + sessionNumber + "] You said '" + inLine + "'";
                                        outStream.WriteLine(outLine); // send a message to client
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