using System;
using System.Collections.Generic;
using System.Text;

namespace p0
{
    public class OrderItem
    {
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public int quantity { get; set; }

        public override string ToString() { 
            return OrderItemId + " " + OrderId + " " + ProductName + " " + quantity;
        }
    }
}
