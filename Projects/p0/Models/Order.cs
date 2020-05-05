using System.Collections.Generic;

namespace p0
{
    public class Order
    {
        public string OrderId { get; set; }
        public float Total { get; set; }
        public string OrderDate { get; set; }

        // FK(s)
        public string CustomerId { get; set; }
        public string LocationId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        
        public override string ToString()
        {
            return OrderId + " " + CustomerId + " " + LocationId + " " + Total + " " + OrderDate; 
        }
    }
}
