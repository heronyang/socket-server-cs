using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Example
{
    class Server
    {
        public const int PORT = 12345;
        public const int BUFFER_SIZE = 1024;

        static void Main(string[] args)
        {
            RunServer();
        }

        public static void RunServer()
        {
            IPEndPoint localEndPoint = new IPEndPoint(/*localhost*/0, PORT);
            Socket listener = new Socket(localEndPoint.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                while (true)
                {
                    Console.WriteLine("Waiting connection ... ");
                    Socket clientSocket = listener.Accept();
                    Console.WriteLine("Connection accepted!");

                    byte[] buffer = new byte[BUFFER_SIZE];
                    while (true)
                    {
                        int numBytesReceived = clientSocket.Receive(buffer);
                        string data = Encoding.ASCII.GetString(buffer,
                                                   0, numBytesReceived);
                        if (numBytesReceived < 1 || buffer[0] == '@')
                        {
                            break;
                        }
                        Console.WriteLine("Received (size={0}): {1}", numBytesReceived, data);
                    }

                    byte[] message = Encoding.ASCII.GetBytes("Bye bye from server.\n");
                    clientSocket.Send(message);

                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
