﻿using DataServer.Models;

namespace DataServer.Models
{
    public class OrderItem
    {
        public long OrderItemId { get; set; }
        public long OrderId { get; set; }
        public int MenuId { get; set; }
        public int Quantity { get; set; }
    }
}