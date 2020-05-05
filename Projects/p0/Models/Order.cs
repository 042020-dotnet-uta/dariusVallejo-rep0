using System.Collections.Generic;

namespace p0
{
    public class Order
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
