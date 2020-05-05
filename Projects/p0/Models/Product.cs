using System;
using System.Collections.Generic;
using System.Text;

namespace p0
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }

        // FK(s)
        public List<Inventory> Inventories { get; set; }
    }
}
