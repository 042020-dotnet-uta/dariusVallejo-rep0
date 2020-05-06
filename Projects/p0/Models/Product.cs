using System.Collections.Generic;

namespace p0
{
    /// <summary>
    /// A model representing a particular product offered
    /// </summary>
    public class Product
    {
        // Keys / columns required to be public
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }

        // Foreign key(s)
        public List<Inventory> Inventories { get; set; }

        /// <summary>
        /// Returns specific fields of the model as a string
        /// </summary>
        /// <returns>A string containing model values</returns>
        public override string ToString()
        {
            return (ProductId + "  " + ProductName + " " + ProductPrice);
        }
    }
}
