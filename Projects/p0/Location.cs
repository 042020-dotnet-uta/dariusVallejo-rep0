using System;
using System.Collections.Generic;
using System.Text;

namespace p0
{
    class Location
    {
        public string LocationId { get; set; }
        public string locationName { get; set; }
        public List<Inventory> inventory { get; set; }
    }
}
