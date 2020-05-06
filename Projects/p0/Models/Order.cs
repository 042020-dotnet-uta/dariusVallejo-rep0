using System.Collections.Generic;

namespace p0
{
    /// <summary>
    /// A model representing a specific order placed in the system
    /// </summary>
    public class Order
    {
        // Keys / columns required to be public
        public string OrderId { get; set; }
        public float Total { get; set; }
        public string OrderDate { get; set; }

        // Foreign key(s)
        public string CustomerId { get; set; }
        public string LocationId { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Returns specific fields of the model as a string
        /// </summary>
        /// <returns>A string containing model values</returns>
        public override string ToString()
        {
            return OrderId + " " + CustomerId + " " + LocationId + " " + Total + " " + OrderDate; 
        }
    }
}
