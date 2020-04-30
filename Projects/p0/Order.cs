using System;
using System.Collections.Generic;
using System.Text;

namespace p0
{
    class Order
    {
        public int OrderId { get; set; }
        public int CustomerID { get; set; }
        public List<Item> Items { get; set; }
    }
}
