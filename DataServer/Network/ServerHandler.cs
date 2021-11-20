using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using DataServer.DataAccess;
using DataServer.Models;
using DataServer.DataAccess;
using DataServer.Network;

namespace DataServer.Network
{
    public class ServerHandler
    {
        private TcpClient client;
        private IDaoFactory daoFactory;
        
        private StreamWriter writer;
        private StreamReader reader;

        private bool clientConnected;
        
        public ServerHandler(TcpClient client, IDaoFactory daoFactory)
        {
            this.client = client;
            this.daoFactory = daoFactory;

            NetworkStream stream = client.GetStream();
            writer = new StreamWriter(stream, Encoding.ASCII){AutoFlush = true};
            reader = new StreamReader(stream, Encoding.ASCII);

        }

        public async Task Start()
        {
            clientConnected = true;
            Console.WriteLine("Server Handler started");
            do
            {
                try
                {
                    // What type of service is it?
                    var serviceType = await reader.ReadLineAsync();
                    Console.WriteLine(serviceType);
                    IHandler handler = GetRequestHandler(serviceType);
                    // What type of request is it?
                    var requestType = await reader.ReadLineAsync();
                    Console.WriteLine(requestType);
                    // Any additional arguments?
                    var args = await reader.ReadLineAsync();
                    Console.WriteLine(args);
                    string jsonObject = await handler.ProcessClientRequestType(requestType, args);
                    Console.WriteLine(jsonObject);
                    await writer.WriteLineAsync(jsonObject);
                
                }
                catch (IOException e)
                {
                    clientConnected = false;
                }
            } while (clientConnected);
            client.Close();
        }

        private IHandler GetRequestHandler(string requestType)
        {
            switch (requestType)
            {
                case "Orders":
                    return new OrdersHandler(daoFactory);
                case "Menus":
                    return new MenusHandler(daoFactory);
                case "MenuItems":
                    return new MenuItemsHandler(daoFactory);
                default:
                    return null;
            }
        }
        
    }
}