using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using DataServer.DataAccess;

namespace DataServer.Network
{
    public class Server
    {
        private IPAddress address;
        private int port;
        private TcpListener server;
        private IDaoFactory daoFactory;

        public Server(IPAddress address, int port, IDaoFactory daoFactory)
        {
            this.daoFactory = daoFactory;
            this.address = address;
            this.port = port;
        }

        public void Listen()
        {
            try
            {
                server = new TcpListener(address, port);
                
                server.Start();
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client accepted");

                    //here we could start a different handler depending on the client connected
                    ServerHandler handler = new ServerHandler(client, daoFactory);
                    Thread thread = new Thread(h => handler.Start());
                    thread.Start();

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}