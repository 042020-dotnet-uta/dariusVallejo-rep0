using System;
using System.Collections.Generic;
using System.Text;

namespace p0
{
    public class OrderItem
    {
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

        public override string ToString() { 
            return OrderItemId + " " + OrderId + " " + ProductId + " " + Quantity;
        }
    }
}
