using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class Client
    {
        //public static void Main(string[] args)
        //{
        //    ExecuteClient();
        //}

        /*
         Main functions that client socket uses:
        1.Socket sender = new socket(...);
        2.sender.connect() -- conects to ipaddress + port
        3.sender.send() -- sends data to ipaddress + port and returns in ints how many bytes where sent
        4.sender.receive(byte[] arr) -- it fills array with recieved info and returns how many bytes where recieved
        5.sender.shutdown() -- stops recieving and sending(you can say which one to turn of using enum)
        6.sender.close() -- closes the socket and frees up system resources
         
         */
        public static void ExecuteClient()
        {
            try
            {
                // Creating Local endpoint for both socket and client to use
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11115);

                // Creation TCP/IP Socket using 
                // Socket Class Constructor

                Socket sender = new Socket(ipAddr.AddressFamily,
                           SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    // clients socket connects to port11111 , where server listens
                    sender.Connect(localEndPoint);

                    // this will print: socket conneted to -> 192.168.1.10:11111
                    Console.WriteLine("Socket connected to -> {0} ",
                         sender.RemoteEndPoint.ToString());

                    // this will send 1024 or less bytes to port11111 so server that listens port11111 can recieve it
                    byte[] messageSent = Encoding.ASCII.GetBytes("Chemi pirveli mesiji<EOF>");
                    // this is optional
                    int byteSent = sender.Send(messageSent);

                    byte[] messageReceived = new byte[1024];

                    // how many bytes did we recieve that server sent us?
                    int byteReceived = sender.Receive(messageReceived);

                    Console.WriteLine("Message from Server -> {0}",
                  Encoding.ASCII.GetString(messageReceived,
                                             0, byteReceived));

                    // stops both sending end recieving
                    sender.Shutdown(SocketShutdown.Both);
                    // closes the socket and frees up system resources
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


        }

    }
}
