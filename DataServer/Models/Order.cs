﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using DatabaseServer.Models;

namespace DataServer.Models
{
    public class Order
    {
        public long OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryTime { get; set; }
        public decimal Price { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        public Customer Customer { get; set; }
        public Status Status { get; set; }
        
        public Address DeliveryAddress { get; set; }
        
        
        // TESTING
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

    }
}