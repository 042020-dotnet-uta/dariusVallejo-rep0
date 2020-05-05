using System.Collections.Generic;

namespace p0
{
    public class Location
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }

        // FK(s)
        public List<Inventory> Inventories { get; set; }
    }
}
