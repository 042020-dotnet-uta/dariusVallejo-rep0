using System;
using System.Collections.Generic;
using System.Text;

namespace p0
{
    /// <summary>
    /// A model representing a line item for a specific order
    /// </summary>
    public class OrderItem
    {
        // Keys / columns required to be public
        public string OrderItemId { get; set; }
        public int Quantity { get; set; }

        // Foreign key(s)
        public string OrderId { get; set; }
        public string ProductId { get; set; }

        /// <summary>
        /// Returns specific fields of the model as a string
        /// </summary>
        /// <returns>A string containing model values</returns>
        public override string ToString() { 
            return OrderItemId + " " + OrderId + " " + ProductId + " " + Quantity;
        }
    }
}
