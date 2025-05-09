﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class Server
    {
        public static void Main(string[] args)
        {
            ExecuteServer();
        }

        public static void ExecuteServer()
        {
            // creating endpoint again
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11115);


            // creating TCP/IP Socket again
            Socket listener = new Socket(ipAddr.AddressFamily,
                 SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Bind the sercer socket to the local endpoint 
                listener.Bind(localEndPoint);

                // Listen for incoming connections
                listener.Listen(10);

                while (true)
                {
                    Console.WriteLine("Waiting connection ... ");

                    // blocks until a client has connected to the server
                    Socket clientSocket = listener.Accept();

                    byte[] bytes = new Byte[1024];
                    string data = null;


                    while (true)
                    {

                        int numByte = clientSocket.Receive(bytes);

                        data += Encoding.ASCII.GetString(bytes,
                                                   0, numByte);

                        if (data.IndexOf("<EOF>") > -1)
                            break;
                    }

                    Console.WriteLine("Text received -> {0} ", data);
                    byte[] message = Encoding.ASCII.GetBytes("Test Server");

                    // Send a message to Client 
                    // using Send() method
                    clientSocket.Send(message);

                    // Close client Socket using the
                    // Close() method. After closing,
                    // we can use the closed Socket 
                    // for a new Client Connection
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();

                    listener.Shutdown(SocketShutdown.Both);  // Shuts down the server socket
                    listener.Close();  // Releases the server socket
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
