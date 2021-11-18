using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Models;
using Microsoft.AspNetCore.Http.Features;

namespace WebClient.Data
{
    public class InfoService : IInfoService
    {
        private readonly HttpClient client;
        private JsonSerializerOptions item;
        private string uri = "http://localhost:8080";

        public InfoService()
        {
            client = new HttpClient();
            item = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<Address> AddInfoOrderAsync(Address infoOrder)
        {
            string infoAsJson = JsonSerializer.Serialize(infoOrder);
            HttpContent content = new StringContent(infoAsJson, Encoding.UTF8, "application.json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "Order Information", content);
            if (!responseMessage.IsSuccessStatusCode) 
                
                throw new Exception($"Error, {responseMessage.StatusCode},{responseMessage.ReasonPhrase}");
            return infoOrder;
        }

        public async Task<List<OrderItem>> GetOrderItems(OrderItem orderItem)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/orderItems/{orderItem}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            List<OrderItem> orderItems = JsonSerializer.Deserialize<List<OrderItem>>(result, item);
            return orderItems;
        }

        

        public async Task<IList<OrderItem>> GetOrderItems()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Address>> AddInfoOrderAsync()
        {
            throw new NotImplementedException();
        }
    }
        
    }
    
        

        
