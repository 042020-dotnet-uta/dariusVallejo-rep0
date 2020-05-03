using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace p0
{
    class Order
    {
        public string OrderId { get; set; }
        public string CustomerId { get; set; }
        public string LocationId { get; set; }
        public float total { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public string orderDate { get; set; }
        
        public override string ToString()
        {
            return OrderId + " " + CustomerId + " " + LocationId + " " + total + " " + orderDate; 
        }
    }
}
